using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.Entity.Mappings
{
    public class GaleriFotografMapping : EntityTypeConfiguration<GaleriFotograf>
    {
        public GaleriFotografMapping()
        {
            Property(x => x.FotografUrl).HasMaxLength(500);
        }
    }
}
