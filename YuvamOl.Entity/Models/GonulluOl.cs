using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models.Enums;

namespace YuvamOl.Entity.Models
{
    public class GonulluOl:BaseEntity
    {
      
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string EMail { get; set; }
        public string Telefon { get; set; }
        public string Notlar { get; set; }

        //foreign key
        public int IlceId { get; set; }

        //Navigation Properties
        public virtual Ilce Ilce { get; set; }
    }
}
