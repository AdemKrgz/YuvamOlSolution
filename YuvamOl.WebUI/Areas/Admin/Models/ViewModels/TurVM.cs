using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuvamOl.Entity.Models;

namespace YuvamOl.WebUI.Areas.Admin.Models.ViewModels
{
    public class TurVM
    {
        [AllowHtml]
        public Tur tur { get; set; }
        public IEnumerable<Tur> turler { get; set; }
        public Cins Cins  { get; set; }

    }
}