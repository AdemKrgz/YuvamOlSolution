using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models.Enums;


namespace YuvamOl.Entity.Models
{
    public class IlanDetay : BaseEntity
    {
        public IlanDetay()
        {
            IlanResimleri = new List<IlanFotograf>(); 
            Cinsiyet = false;
            SaglikKarnesiVarMi = false;
        }

        public string UserName { get; set; }

        //Foregin Keys
        public int IlceId { get; set; }
        public int CinsId { get; set; }


        public string IlanBasligi { get; set; }
        public string IlanIcerigi { get; set; }
        public DateTime? IlanBitisTarihi { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        public AsiDurumu? AsiDurum { get; set; }
        public bool SaglikKarnesiVarMi { get; set; }


        //Navgation Properties
        public virtual Ilce Ilce { get; set; }
        public virtual Cins Cins { get; set; }

        //Navgation Properties one-to-many
        public virtual ICollection<IlanFotograf> IlanResimleri { get; set; }
        
    }
}
