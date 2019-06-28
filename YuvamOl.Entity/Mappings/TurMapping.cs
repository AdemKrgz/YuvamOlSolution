using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.Entity.Mappings
{
    public class TurMapping : EntityTypeConfiguration<Tur>
    {
        public TurMapping()
        {
            Property(x => x.Ad).HasMaxLength(50);
            Property(x => x.Aciklama).HasMaxLength(1000);

        }
    }
}
