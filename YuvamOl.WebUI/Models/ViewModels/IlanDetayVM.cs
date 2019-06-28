using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuvamOl.Entity.Models;
using YuvamOl.WebUI.Models.IdentityModels;

namespace YuvamOl.WebUI.Models.ViewModels
{
    public class IlanDetayVM
    {
        [AllowHtml]
        public IlanDetay ilanDetay { get; set; }
        public int TurId { get; set; }
        public int SehirId { get; set; }
        public int CinsId { get; set; }
        public int IlceId { get; set; }

    }
}