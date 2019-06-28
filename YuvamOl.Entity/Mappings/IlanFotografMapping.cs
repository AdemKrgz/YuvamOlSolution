using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.Entity.Mappings
{
    public class IlanFotografMapping : EntityTypeConfiguration<IlanFotograf>
    {
        public IlanFotografMapping()
        {
            Property(x => x.IlanFotografUrl).HasMaxLength(500);
        }
    }
}
