using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuvamOl.BLL.Concretes;
using YuvamOl.BLL.Concretes.BizKimizServices;
using YuvamOl.BLL.Concretes.GonulluOlService;
using YuvamOl.BLL.Concretes.IlanService;
using YuvamOl.BLL.Concretes.PetTurleriService;
using YuvamOl.BLL.Concretes.TanimService;
using YuvamOl.Entity.Models;
using YuvamOl.WebUI.Models.IdentityModels;
using YuvamOl.WebUI.Models.ViewModels;
using static YuvamOl.WebUI.Helper.FileHelper;

namespace YuvamOl.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private GaleriFotografService _galeriFotografService;
        private IlanService _ilanService;
        private SehirService _sehirService;
        private IlceService _ilceService;
        private IlanDetayService _ilanDetayService;
        private BizeUlasinService _bizeUlasinService;
        private TurService _turService;
        private CinsService _cinsService;
        private GonulluOlService _gonulluOlService;
        private static AppUser _user;
        
        public HomeController()
        {



        }

        // GET: Home
        [HttpGet]
        public ActionResult Index(int page = 1, List<Ilan> ilanlar = null)
        {

            /*
            ture göre ilan getir, pagination ile karşılanacak
            */

            TempData["Turler"] = TurGetir();
            _ilanDetayService = new IlanDetayService();
            
            _sehirService = new SehirService();
            var i=_ilanDetayService.WhereSelect().ToList();
            IPagedList<IlanDetay> result = _ilanDetayService.SehireGoreIlanGetir(1).ToPagedList(page, 5);
            TempData["Ilanlar"] = i;
            
            return View();

        }

        public ActionResult IlanDetay(int IlanId = 1)
        {
            TempData["User"] = _user;

            TempData["Sehirler"] = Sehirler();
            TempData["Turler"] = Turler();
            _ilanDetayService = new IlanDetayService();
            TempData["IlanDetay"] = _ilanDetayService.FindById(IlanId);
            _ilanDetayService.Dispose();
            return View();
        }
        public ActionResult IlanGetir()
        {
            TempData["User"] = _user;
            _ilanService = new IlanService();
            if (ModelState.IsValid)
            {
                try
                {
                    //List<Ilan> ilan = _ilanService.WhereSelect(x => x.AktifMi == true).ToList();
                    List<Ilan> ilanListesi = _ilanService.IlanGetir().Where(x => x.AktifMi == true).ToList();

                    if (ilanListesi.Count < 1)
                    {
                        TempData["IlanHatasi"] = "Kayıtlı İlan Bulunmamaktadır.";
                    }
                    else
                    {
                        TempData["IlanGetir"] = ilanListesi;
                        return View("~/Views/Partials/_PartialIlan.cshtml", ilanListesi);
                    }
                }
                catch (Exception ex)
                {
                    TempData["IlanHatasi"] = ex.Message;
                }
            }
            return View();
        }

        public ActionResult SehireGoreIlanGetir(int id)
        {
            TempData["User"] = _user;
            _ilanService = new IlanService();
            if (ModelState.IsValid)
            {
                try
                {
                    List<Ilan> sehirIlanlari = _ilanService.SehireGoreIlanGetir(id).ToList();
                    if (sehirIlanlari.Count < 1)
                    {
                        TempData["IlanHatasi"] = "Kayıtlı İlan Bulunmamaktadır.";
                    }
                    else
                    {
                        return View(sehirIlanlari);
                    }
                }
                catch (Exception ex)
                {

                    TempData["IlanHatasi"] = ex.Message;
                }
            }
            return View();
        }


        public ActionResult SehirGetir(string sehir)
        {
            TempData["User"] = _user;
            _sehirService = new SehirService();
            if (ModelState.IsValid)
            {
                try
                {
                    List<Sehir> sehirler = new List<Sehir>();
                    if (string.IsNullOrEmpty(sehir))
                    {
                        // sehirler = _sehirService.SehirAra("a").ToList();
                        sehirler = _sehirService.SehirGetirService().ToList();
                        if (sehirler.Count < 1)
                        {
                            TempData["ŞehirHatasi"] = "Kayıtlı Şehir Bulunmamaktadır.";
                        }
                        else
                        {
                            TempData["Şehirler"] = sehirler;
                            return PartialView("~/Views/Partials/_PartialSehir.cshtml", sehirler);
                        }
                    }
                    else
                    {
                        sehirler = SehirAra(sehir);
                        return PartialView("~/Views/Partials/_PartialSehir.cshtml", sehirler);
                    }
                }
                catch (Exception ex)
                {
                    TempData["ŞehirHatasi"] = ex.Message;
                }
            }
            return null;
        }

        [HttpGet]
        public ActionResult HarfeGoreHayvanCinsGetir(string ad="A", int turId=2)
        {
            _cinsService = new CinsService();
            _turService = new TurService();
            if (ModelState.IsValid)
            {

                try
                {
                    List<Cins> cinsListesi =  _cinsService.HarfeGoreCinsGetir(ad,turId).ToList();
                    if (cinsListesi.Count < 1)
                    {
                        TempData["CinsHatası"] = "Kayıtlı cins Bulunmamaktadır.";
                      

                    }
                    else
                    {
                        TurVM turvm = new TurVM();
                        var turler = _turService.TurGetir().ToList();
                        turvm.Turler = turler;

                        TempData["Turler"] = turvm.Turler;
                        var tur = _turService.FindById(turId);
                        TempData["Tur"] = tur;
                        var cinsler = tur.Cinsler.ToList();

                        turvm.Cinsler = cinsler;
                        TempData["Cins"] = turvm;
                        TempData["Cinsler"] = cinsler;
                        TempData["Turler"] = _turService.FindById(turId);

                        return Redirect("/Home/PetTurleri");
                    }
                }
                catch (Exception ex)
                {

                    TempData["CinsHatası"] = ex.Message;
                }
            }
            return View();
        }

        [HttpPost]
        public List<Sehir> SehirAra(string sehir)
        {
            _sehirService = new SehirService();
            if (ModelState.IsValid)
            {
                try
                {
                    List<Sehir> sehirler = _sehirService.SehirAra(sehir).ToList();
                    if (sehirler.Count < 1)
                    {
                        TempData["ŞehirHatasi"] = "Kayıtlı Şehir Bulunmamaktadır.";
                    }
                    else
                    {
                        TempData["Şehirler"] = sehirler;
                        return sehirler;
                    }
                }
                catch (Exception ex)
                {
                    TempData["ŞehirHatasi"] = ex.Message;
                }
            }
            return null;
        }

        public ActionResult Hakkimizda()
        {
            TempData["User"] = _user;
            return View();
        }


        [HttpGet]
        public ActionResult GonulluOl(bool hata = false)
        {
            TempData["User"] = _user;
            
            TempData["SehirlerList"] = SelectListSehirler();
            TempData["IlcelerList"] = SelectListIlceler();
            TempData["Ilceler"] = Ilceler(1);
            if (hata)
            {
                TempData["message"] = $"Bir Hata Oluştu!";
                TempData["css"] = "danger";
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GonulluOl(GonulluOlVM model)
        {
            _gonulluOlService = new GonulluOlService();
            _ilceService = new IlceService();
            model.SehirList = SelectListSehirler();
            model.IlceList = SelectListIlceler();
            Ilce ilce = new Ilce();
            ilce = _ilceService.FindById(model.GonulluOl.IlceId);
            model.GonulluOl.Ilce = ilce;
            _ilceService.Dispose();
            
                try
                {

                    _gonulluOlService.AddGonulluOlService(model.GonulluOl);
                    TempData["Ilceler"] = Ilceler(model.GonulluOl.Ilce.SehirId);
                    TempData["message"] = "Gönüllü Olduğunuz İçin Teşekkür Ederiz";
                    TempData["css"] = "success";
                    return View();
                }
                catch (Exception ex)
                {
                    TempData["message"] = $"Bir Hata Oluştu! Hatanız:{ex.Message}";
                    TempData["css"] = "danger";
                    return RedirectToAction("GonulluOl", new { hata = true });
                }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult GonulluOlIlceGetir(GonulluOlVM model,int SehirId = 1)
        {
            _sehirService = new SehirService();
            List<Ilce> ilceler = _sehirService.FindById(SehirId).Ilceler.ToList();
            if (ilceler.Count < 1)
            {
                TempData["IlceHatasi"] = "Kayıtlı İlce Bulunmamaktadır.";
            }
            else
            {
                TempData["IlcelerList"] = SelectListIlceler();

                return PartialView("~/Views/Partials/_PartialIlceGetir.cshtml", Ilceler(SehirId));
            }
            return null;
        }
        public ActionResult Galeri()
        {
            TempData["User"] = _user;
            _galeriFotografService = new GaleriFotografService();
            List<Entity.Models.GaleriFotograf> fotoList = _galeriFotografService.WhereSelect(x => x.AktifMi == true).ToList();
            return View(fotoList);
        }
        [HttpGet]
        public ActionResult Iletisim()
        {
            TempData["User"] = _user;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Iletisim(IletisimVM model)
        {
            _bizeUlasinService = new BizeUlasinService();
            _bizeUlasinService.Add(model.bizeUlasin);
            return View();
        }

        [HttpGet]
        public ActionResult IlanEkle(int TurId = 1, int SehirId = 1)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UyeOl");
            }

            TempData["User"] = _user;
            TempData["TurlerList"] = SelectListTurler();
            TempData["CinslerList"] = SelectListCinsler();
            TempData["SehirlerList"] = SelectListSehirler();
            TempData["IlcelerList"] = SelectListIlceler();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult IlanEkle(IlanDetayVM model, IEnumerable<HttpPostedFileBase> file)
        {
            if (ModelState.IsValid)
            {
                //_cinsService = new CinsService();
                //_cinsService.UpdateCins(model.ilanDetay.Cins);
                //_cinsService.Dispose();
                try
                {
                    string physicalPath = "~/Content/Images/GaleriFotograf";
                    int maxFileSize = 500000;

                    Dictionary<FileResultItem, FileResultType> resultModel = FileDocumentUpload(file, maxFileSize, physicalPath, new string[] { "image/gif", "image/png", "image/jpeg", "image/pjpeg", "image/bmp", "image/x-png", "image/jpg" });

                    foreach (KeyValuePair<FileResultItem, FileResultType> item in resultModel)
                    {
                        if (item.Value == FileResultType.Error || item.Value == FileResultType.NoneFile || item.Value == FileResultType.SizeOver || item.Value == FileResultType.WrongType)
                        {
                            RemoveAll(resultModel.Keys, physicalPath);
                            TempData["NoteCss"] = "warning";
                            TempData["NoteText"] = ControlMessages(item.Value, maxFileSize).Keys.FirstOrDefault().ToString();

                            return View();
                        }
                    }

                    foreach (FileResultItem item in resultModel.Keys)
                    {
                        model.ilanDetay.IlanResimleri.Add(new IlanFotograf { IlanFotografUrl = item.UploadPath });
                    }
                    _ilanDetayService = new IlanDetayService();
                    _ilanDetayService.AddIlanDetay(model.ilanDetay);
                    _ilanDetayService.Dispose();
                    _ilanService = new IlanService();


                    _ilanService.Add(new Ilan
                    {
                        IlanBasligi = model.ilanDetay.IlanBasligi,
                        ResimUrl = model.ilanDetay.IlanResimleri.FirstOrDefault().IlanFotografUrl,
                        Tur = model.ilanDetay.Cins.Tur,
                        AktifMi = true,
                        Ilce = model.ilanDetay.Ilce,
                        OlusturmaTarihi = DateTime.Now

                    });

                    TempData["message"] = "Fotoğraf Başarıyla Eklendi.";
                    TempData["css"] = "success";
                    return RedirectToAction("IlanEkle");

                }
                catch (Exception ex)
                {

                    TempData["message"] = $"Bir Hata Oluştu! Hatanız:{ex.Message}";
                    TempData["css"] = "danger";

                }
                
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult CinsGetir(int TurId = 1)
        {
            _turService = new TurService();
            List<Cins> cinsler = _turService.FindById(TurId).Cinsler.ToList();
            if (cinsler.Count < 1)
            {
                TempData["CinsHatasi"] = "Kayıtlı Cins Bulunmamaktadır.";
            }
            else
            {
                
                var cinslist = new List<Cins>();
                cinslist.Add(new Cins { Id = 0, Ad = "Cins Seçin" });
                cinslist.AddRange(cinsler);
                TempData["CinslerList"] = new SelectList(cinslist, "Id", "Ad");

                return PartialView("~/Views/Partials/_PartialCinsGetir.cshtml", cinsler);
            }

            return null;
        }
        [HttpGet]
        public List<Tur> TurGetir()
        {
            _turService = new TurService();
            List<Tur> turler = new List<Tur>();
            try
            {
                turler = _turService.TurGetir().ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Hata = ex.Message;
            }
            return turler;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult PetTurleriGetir(string turAdi)
        {
            _ilanService = new IlanService();
            List<Ilan> petİlanlari = _ilanService.IlanGetir(turAdi).ToList();
            if (petİlanlari.Count < 1)
            {
                TempData["CinsHatasi"] = "Kayıtlı Tur Bulunmamaktadır.";
            }
            else
            {
                ViewBag.turler = new SelectList(petİlanlari, "Id", "Ad");
                return PartialView("~/Views/Partials/_PartialPetTurleri.cshtml", petİlanlari);
            }

            return null;
        }
        public List<Cins> IlanCinsGetir(int TurId = 1)
        {
            _turService = new TurService();
            List<Tur> turler = TurGetir();
            List<Cins> cinsler = new List<Cins>();
            try
            {
                cinsler = _turService.FindById(TurId).Cinsler.ToList();
            }
            catch (Exception ex)
            {
                ViewBag.Hata = ex.Message;
            }
            return cinsler;
        }

        public ActionResult PaginationGetir(string id)
        {
            _cinsService = new CinsService();
            TempData["User"] = _user;
            return View(_cinsService.CinsGetir(id));
        }
        public ActionResult PetTuruneGoreIlanGetir(int TurId = 1)
        {
            TempData["User"] = _user;
            _ilanService = new IlanService();
            TempData["Ilanlar"] = _ilanService.TureGoreIlan(TurId).ToList();
            return RedirectToAction("Index", new { ilanlar = TempData["Ilanlar"] });
        }

        [HttpGet]
        public ActionResult PetTurleri(int TurId = 1)
        {
            _turService = new TurService();
            TurVM turvm = new TurVM();
            var turler= _turService.TurGetir().ToList();
            turvm.Turler = turler;
            TempData["Turler"] = turvm.Turler;
            var tur= _turService.FindById(TurId);
            TempData["Tur"] = tur;
            var cinsler= tur.Cinsler.ToList();
            
            turvm.Cinsler = cinsler;
            TempData["Cins"] = turvm;
            TempData["Cinsler"] = cinsler;

            return View();
        }
        //[HttpGet]
        //public ActionResult Cinsler(int CinsId=1)
        //{
        //    _cinsService = new CinsService();
        //    TempData["Cinsler"] = _cinsService.CinsGetir().ToList();
        //    TempData["Cins"] = _cinsService.FindById(CinsId);
        //    return View();

        //}

        [HttpGet]
        public ActionResult UyeOl()
        {
            return View();
        }

        public PartialViewResult IlceGetir(int SehirId = 1)
        {
            _sehirService = new SehirService();
            List<Ilce> ilceler = _sehirService.FindById(SehirId).Ilceler.ToList();
            if (ilceler.Count < 1)
            {
                TempData["IlceHatasi"] = "Kayıtlı Ilce Bulunmamaktadır.";
            }
            else
            {
                var ilcelist = new List<Ilce>();
                ilcelist.Add(new Ilce { Id = 0, Ad = "İlçe Seçin" });
                ilcelist.AddRange(ilceler);
                TempData["IlcelerList"] = new SelectList(ilcelist, "Id", "Ad");
                return PartialView("~/Views/Partials/_PartialIlceGetir.cshtml", ilceler);
            }
            return null;
        }


        #region Dropdownlist JSON
        
        public JsonResult IlceList(int SehirId)
        {
            _sehirService = new SehirService();
            List<Ilce> ilceler = _sehirService.FindById(SehirId).Ilceler.ToList();

            List<SelectListItem> itemlist = (from i in ilceler
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Ad
                                             }).ToList();

            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CinsList(int TurId)
        {
            List<Cins> cinsler = Cinsler(TurId);

            List<SelectListItem> itemlist = (from i in cinsler
                                             select new SelectListItem
                                             {
                                                 Value = i.Id.ToString(),
                                                 Text = i.Ad
                                             }).ToList();

            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SelectListItemGetirmeMetodlari

        public SelectList SelectListSehirler()
        {
            var _sehirService = new SehirService();
            var sehirlist = new List<Sehir>();
            sehirlist.Add(new Sehir { Id = 0, Ad = "Şehir Seçin" });
            sehirlist.AddRange(_sehirService.SehirGetir().ToList());
            var result= new SelectList(sehirlist, "Id", "Ad", new { Id = 0, Ad = "Şehir Seçin", Selected = true });

            return result;
        }
        public SelectList SelectListIlceler(int SehirId = 1)
        {
            var _sehirService = new SehirService();
            var ilcelist = new List<Ilce>();
            ilcelist.Add(new Ilce { Id = 0, Ad = "İlce Seçin" });
            ilcelist.AddRange(_sehirService.FindById(SehirId).Ilceler.ToList());
            var result = new SelectList(ilcelist, "Id", "Ad", new { Id = 0, Ad = "Şehir Seçin", Selected = true });
            return result;
        }
        public SelectList SelectListTurler()
        {
            var _turService = new TurService();
            var turlist = new List<Tur>();
            turlist.Add(new Tur { Id = 0, Ad = "Tur Seçin" });
            turlist.AddRange(_turService.TurGetir().ToList());
            var result = new SelectList(turlist, "Id", "Ad", new { Id = 0, Ad = "Tur Seçin", Selected = true });

            return result;
        }
        public SelectList SelectListCinsler(int TurId = 1)
        {
            var _turService = new TurService();
            var cinslist = new List<Cins>();
            cinslist.Add(new Cins { Id = 0, Ad = "Cins Seçin" });
            cinslist.AddRange(_turService.FindById(TurId).Cinsler.ToList());
            var result = new SelectList(cinslist, "Id", "Ad", new { Id = 0, Ad = "Cins Seçin", Selected = true });
            return result;
        }
        #endregion

        #region dropdownlist için data getirme

        public List<Sehir> Sehirler()
        {
            _sehirService = new SehirService();
            return _sehirService.SehirGetir().ToList();
        }
        public List<Ilce> Ilceler(int SehirId)
        {
            _sehirService = new SehirService();
           return _sehirService.FindById(SehirId).Ilceler.ToList();

        }
        public List<Tur> Turler()
        {
            _turService = new TurService();
            return _turService.TurGetir().ToList();

        }
        public List<Cins> Cinsler(int TurId)
        {
            _turService = new TurService();
            return _turService.FindById(TurId).Cinsler.ToList();

        }

        #endregion
    }

}