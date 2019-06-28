using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuvamOl.Entity.Models
{
    public class IlanFotograf : BaseEntity
    {
        //Foreign Keys
        public int? IlanId { get; set; }
        public int? IlanDetayId { get; set; }
        public string IlanFotografUrl { get; set; }


        //Navgation Properties
        public virtual Ilan Ilan { get; set; }
        public virtual IlanDetay IlanDetay { get; set; }
    }
}
