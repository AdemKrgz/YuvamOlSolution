using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.Entity.Mappings
{
    public class BizeUlasinMapping : EntityTypeConfiguration<BizeUlasin>
    {
        public BizeUlasinMapping()
        {
        Property(x => x.AdSoyad).HasMaxLength(100);
        Property(x => x.EPosta).HasMaxLength(100);
        Property(x => x.Mesaj).HasMaxLength(1000);

        }
    }
}
