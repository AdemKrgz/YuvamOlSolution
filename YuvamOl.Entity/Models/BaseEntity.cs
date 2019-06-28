using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuvamOl.Entity.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            OlusturmaTarihi = DateTime.Now;
            AktifMi = true;
        }
        public int Id { get; set; } 
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime? DuzenlemeTarihi { get; set; }
        public bool AktifMi { get; set; }
    }
}
