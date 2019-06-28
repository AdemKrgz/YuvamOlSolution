using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YuvamOl.Entity.Models
{
    public class Cins : BaseTanim
    {

        public Cins()
        {
            IlanDetaylari = new List<IlanDetay>();

        }
        //Foreign keys
        public int TurId { get; set; }

       
        public string IconUrl { get; set; }
        
        public string Detay { get; set; }

        public virtual ICollection<IlanDetay> IlanDetaylari { get; set; }
        //navigaton properties
        public virtual Tur Tur { get; set; }

    }
}