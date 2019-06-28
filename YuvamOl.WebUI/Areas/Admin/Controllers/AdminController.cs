using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuvamOl.BLL.Concretes.BizKimizServices;
using YuvamOl.BLL.Concretes.GonulluOlService;
using YuvamOl.BLL.Concretes.TanimService;
using YuvamOl.Entity.Models;
using YuvamOl.WebUI.Areas.Admin.Models.ViewModels;
using YuvamOl.WebUI.Models.ViewModels;
using static YuvamOl.WebUI.Helper.FileHelper;
using TurVM = YuvamOl.WebUI.Areas.Admin.Models.ViewModels.TurVM;

namespace YuvamOl.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //kullanıcı adi = Admin, şifre = 123456,
        TurService _turService;
        CinsService _cinsService;
        BizeUlasinService _bizeUlasinService;
        GonulluOlService _gonulluOlService;
        public AdminController()
        {
            _turService = new TurService();
            _cinsService = new CinsService();
            _bizeUlasinService = new BizeUlasinService();
            _gonulluOlService = new GonulluOlService();

        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Türü ekleme")]
        public ActionResult TurAdd()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult TurAdd(TurVM model)
        {

            ICollection<Tur> turler = _turService.TurGetir();
            foreach (var item in turler)
            {
                if (item.Ad == model.tur.Ad)
                {
                    TempData["message"] = "Tür zaten mevcut!";
                    TempData["css"] = "danger";
                    return View();
                }
            }
            if (model.tur.Ad == null || model.tur.Aciklama == null)
            {
                TempData["message"] = "Alanları eksiksiz doldurun!";
                TempData["css"] = "danger";
                return View();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _turService.Add(model.tur);
                    TempData["message"] = "Tür Başarıyla Eklenmiştir..";
                    TempData["css"] = "success";
                    return View();

                }
                catch (Exception ex)
                {
                    TempData["message"] = $"Bir Hata Oluştu! Hatanız:{ex.Message}";
                    TempData["css"] = "danger";
                    return View(model);
                }

            }
            else
            {
                TempData["message"] = "Lütfen Alanlarınızı Kontrol Ediniz.";
                TempData["css"] = "danger";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult TurListele()
        {
            //List<KullaniciIletisim> kullaniciListe = _db.Kullanici.ToList();

            return View(_turService.TurGetir());
        }

        [HttpGet]
        public ActionResult TurDelete(int id)
        {
            Tur seciliTur = _turService.WhereSelect(x => x.Id == id).FirstOrDefault();
            return View(seciliTur);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult TurDelete(Tur model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _turService.Delete(model.Id);

                    TempData["css"] = "danger";
                    TempData["Message"] = "Tür Silindi!";

                    return RedirectToAction("TurListele");

                }
                else
                {
                    TempData["css"] = "warning";
                    TempData["Message"] = "Lütfen Alanlarınızı Kontrol Ediniz!";
                    return RedirectToAction("TurListele");

                }
            }
            catch (Exception ex)
            {

                TempData["CSS"] = "danger";
                TempData["Message"] = $"Hata Oluştu. Hata Mesajı: {ex.Message}";
                return RedirectToAction("TurListele");
            }
        }
        [HttpGet]
        public ActionResult TurUpdate(int id)
        {

            Tur seciliTur = _turService.WhereSelect(x => x.Id == id).FirstOrDefault();
            return View(seciliTur);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TurUpdate(Tur model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Tur eskiTur = _turService.WhereSelect(x => x.Id == model.Id).FirstOrDefault();
                    eskiTur.Ad = model.Ad;
                    eskiTur.Aciklama = model.Aciklama;
                    _turService.Update(eskiTur);
                    TempData["CSS"] = "success";
                    TempData["Message"] = "Tür Güncelleme İşleminiz Başarıyla Gerçekleşti";
                    return RedirectToAction("TurListele");
                }
                else
                {
                    TempData["CSS"] = "warning";
                    TempData["Message"] = "Lütfen Alanlarınızı Kontrol Ediniz!";
                }
            }
            catch (Exception ex)
            {
                TempData["CSS"] = "danger";
                TempData["Message"] = $"Hata Oluştu. Hata Mesajı: {ex.Message}";
            }
            return View();
        }
        [HttpGet]
        public ActionResult CinsAdd()
        {
            ViewBag.TurleriGetir = new SelectList(_turService.TurGetir(), "Id", "Ad");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CinsAdd(CinsVM model, IEnumerable<HttpPostedFileBase> file)
        {
            ICollection<Cins> cinsler = _cinsService.CinsGetir();
            foreach (var item in cinsler)
            {
                if (item.Ad == model.cins.Ad)
                {
                    TempData["message"] = "Cins zaten mevcut!";
                    TempData["css"] = "danger";
                    return View();
                }
            }
            if (model.cins.Ad == null || model.cins.Detay == null)
            {
                TempData["message"] = "Alanları eksiksiz doldurun!";
                TempData["css"] = "danger";
                return View();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string physicalPath = "~/Content/Images/CinsIcon";//d//
                    int maxFileSize = 500000;//d//
                    Dictionary<FileResultItem, FileResultType> resultModel = FileDocumentUpload(file, maxFileSize, physicalPath, new string[] { "image/gif", "image/png", "image/jpeg", "image/pjpeg", "image/bmp", "image/x-png", "image/jpg" });//d//
                    foreach (var item in resultModel)
                    {
                        if (item.Value == FileResultType.Error || item.Value == FileResultType.NoneFile || item.Value == FileResultType.SizeOver || item.Value == FileResultType.WrongType)
                        {
                            RemoveAll(resultModel.Keys, physicalPath);

                            TempData["message"] = "Fotoğraf yüklenmeye uygun değil!";
                            TempData["css"] = "danger";

                            return View();
                        }
                    }//d//
                    foreach (var item in resultModel.Keys)
                    {
                        model.cins.IconUrl = new Cins { IconUrl = item.UploadPath }.IconUrl;
                    }
                    Tur tur = _turService.FindById(model.turId);
                    tur.Cinsler.Add(model.cins);
                    _turService.Update(tur);
                    TempData["message"] = "Cins Başarıyla Eklenmiştir..";
                    TempData["css"] = "success";
                    return View(model);
                    return View(CinsAdd());

                }
                catch (Exception ex)
                {

                    TempData["message"] = $"Bir Hata Oluştu! Hatanız:{ex.Message}";
                    TempData["css"] = "danger";
                    return View(model);
                }
            }
            else
            {
                TempData["message"] = "Lütfen Alanlarınızı Kontrol Ediniz.";
                TempData["css"] = "danger";
                return View(model);
            }

        }
        [HttpGet]
        public ActionResult CinsListele()
        {
            return View(_cinsService.CinsGetir());
        }


        //[HttpGet]
        //public ActionResult CinsDelete(int id)
        //{
        //    Cins seciliCins = _cinsService.WhereSelect(x => x.Id == id).FirstOrDefault();
        //    return View(seciliCins);
        //}
        //[HttpPost]
        //[ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        //public ActionResult CinsDelete(Cins model)
        //{
        //    try
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            _cinsService.Delete(model.Id);

        //            TempData["css"] = "danger";
        //            TempData["Message"] = "Cins Silindi!";

        //            return RedirectToAction("TurListele");

        //        }
        //        else
        //        {
        //            TempData["css"] = "warning";
        //            TempData["Message"] = "Lütfen Alanlarınızı Kontrol Ediniz!";
        //            return RedirectToAction("CinsListele");

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        TempData["CSS"] = "danger";
        //        TempData["Message"] = $"Hata Oluştu. Hata Mesajı: {ex.Message}";
        //        return RedirectToAction("CinsListele");
        //    }
        //}
        [HttpGet]
        public ActionResult BizeUlasin()
        {
           
            return View(_bizeUlasinService.BizeUlasinGetir());
            
            
        }
     

        [HttpGet] 
        public ActionResult GonulluOl()
        {

            return View(_gonulluOlService.gonulluGetir());
        }

        [HttpGet]
        public ActionResult BizeUlasinDelete(int id)
        {
            BizeUlasin biz = _bizeUlasinService.WhereSelect(x => x.Id == id).FirstOrDefault();
            return View(biz);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult BizeUlasinDelete(Tur model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _bizeUlasinService.Delete(model.Id);

                    TempData["css"] = "danger";
                    TempData["Message"] = "Mesaj Silindi!";

                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["css"] = "warning";
                    TempData["Message"] = "Lütfen Alanlarınızı Kontrol Ediniz!";
                    return RedirectToAction("BizeUlasin");

                }
            }
            catch (Exception ex)
            {

                TempData["CSS"] = "danger";
                TempData["Message"] = $"Hata Oluştu. Hata Mesajı: {ex.Message}";
                return RedirectToAction("BizeUlasin");
            }
        }
    }
}

