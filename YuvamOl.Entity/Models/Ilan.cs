using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuvamOl.Entity.Models
{
    public class Ilan : BaseEntity
    {
        public string ResimUrl { get; set; }
        public string IlanBasligi { get; set; }

        //Foreign Keys
        public int IlceId { get; set; }
        public int TurId { get; set; }

        //Navgation Properties
        public virtual Tur Tur { get; set; }
        public virtual Ilce Ilce { get; set; }

        
    }
}
