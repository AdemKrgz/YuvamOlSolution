using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YuvamOl.Entity.Models;

namespace YuvamOl.WebUI.Models.ViewModels
{
    public class TurVM
    {
        public List<Tur> Turler { get; set; }
        public List<Cins> Cinsler { get; set; }
    }
}