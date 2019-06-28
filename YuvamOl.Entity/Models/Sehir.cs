using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuvamOl.Entity.Models
{
    public class Sehir : BaseTanim
    {
        public Sehir()
        {
            Ilceler = new List<Ilce>();
        }

        //Navigation Properties
        public virtual ICollection<Ilce> Ilceler { get; set; }
    }
}