using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuvamOl.Entity.Models
{
    public class Tur : BaseTanim
    {
        
        public string Aciklama { get; set; }
        public Tur()
        {
            Cinsler = new List<Cins>();
        }

        //Navigation Properties
        
        public virtual ICollection<Cins>Cinsler  { get; set; }
    }
}