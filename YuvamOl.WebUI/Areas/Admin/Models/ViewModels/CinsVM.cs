using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuvamOl.Entity.Models;

namespace YuvamOl.WebUI.Areas.Admin.Models.ViewModels
{
    public class CinsVM
    {
        public int turId { get; set; }
        public Cins cins { get; set; }
    }
}