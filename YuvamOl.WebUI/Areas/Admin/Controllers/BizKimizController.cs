using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuvamOl.BLL.Concretes.BizKimizServices;
using YuvamOl.Entity.Models;
using YuvamOl.WebUI.Areas.Admin.Models.ViewModels.BizKimizModels;
using static YuvamOl.WebUI.Helper.FileHelper;

namespace YuvamOl.WebUI.Areas.Admin.Controllers
{
    public class BizKimizController : Controller
    {
        private GaleriFotografService _galeriFotografService;
        public BizKimizController()
        {
            _galeriFotografService = new GaleriFotografService();
        }
        // GET: Admin/BizKimiz
        [HttpGet]
        public ActionResult GaleriFotografAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GaleriFotografAdd(GaleriFotografVM model, IEnumerable<HttpPostedFileBase> file)
        {
            
            try
            {
                string physicalPath = "~/Content/Images/GaleriFotograf";
                int maxFileSize = 500000;

                Dictionary<FileResultItem, FileResultType> resultModel = FileDocumentUpload(file, maxFileSize, physicalPath, new string[] { "image/gif", "image/png", "image/jpeg", "image/pjpeg", "image/bmp", "image/x-png", "image/jpg" });

                foreach (var item in resultModel)
                {
                    if (item.Value == FileResultType.Error || item.Value == FileResultType.NoneFile || item.Value == FileResultType.SizeOver || item.Value == FileResultType.WrongType)
                    {
                        RemoveAll(resultModel.Keys, physicalPath);

                        TempData["message"] = "Fotoğraf yüklenmeye uygun değil!";
                        TempData["css"] = "danger";

                        return View();
                    }
                }

                foreach (var item in resultModel.Keys)
                {
                    _galeriFotografService.Add(new GaleriFotograf { FotografUrl = item.UploadPath });
                }

                TempData["message"] = "Fotoğraf Başarıyla Eklendi.";
                TempData["css"] = "success";
            }
            catch (Exception ex)
            {

                TempData["message"] = $"Bir Hata Oluştu! Hatanız:{ex.Message}";
                TempData["css"] = "danger";
            }
            return View();

        }
    }
}