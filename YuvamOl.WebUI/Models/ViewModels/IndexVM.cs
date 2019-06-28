using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuvamOl.Entity.Models;

namespace YuvamOl.WebUI.Models.ViewModels
{
    public class IndexVM : LayoutVM
    {
        public List<Sehir> Sehirler { get; set; }
        public List<Tur> Turler { get; set; }
        public List<Ilan> Ilanlar { get; set; }
    }
}