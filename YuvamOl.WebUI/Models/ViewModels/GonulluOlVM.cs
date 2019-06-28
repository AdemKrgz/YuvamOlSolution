using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YuvamOl.Entity.Models;

namespace YuvamOl.WebUI.Models.ViewModels
{
    public class GonulluOlVM
    {
        public GonulluOl GonulluOl { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public SelectList SehirList { get; set; }
        public SelectList IlceList { get; set; }
    }
}