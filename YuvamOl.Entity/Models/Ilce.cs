using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuvamOl.Entity.Models
{
    public class Ilce : BaseTanim
    {
        public Ilce()
        {
            IlanDetaylari = new List<IlanDetay>();
            Gonulluler = new List<GonulluOl>();
        }

        //Foreign Keys
        public int SehirId { get; set; }
        

        //Navgation Properties
        public virtual ICollection<IlanDetay> IlanDetaylari { get; set; }
        public virtual ICollection<GonulluOl> Gonulluler { get; set; }
        public virtual Sehir Sehir { get; set; }
    }
}
