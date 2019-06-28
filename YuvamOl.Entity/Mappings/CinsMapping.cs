using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.Entity.Mappings
{
    public class CinsMapping : EntityTypeConfiguration<Cins>
    {
        public CinsMapping()
        {
            Property(x => x.Ad).HasMaxLength(50);
            Property(x => x.IconUrl).HasMaxLength(500);
        }

    }
}
