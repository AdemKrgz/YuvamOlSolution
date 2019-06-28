using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.Entity.Mappings
{
    public class IlanDetayMapping : EntityTypeConfiguration<IlanDetay>
    {
        public IlanDetayMapping()
        {
            Property(x => x.IlanBasligi).HasMaxLength(100);
            Property(x => x.IlanIcerigi).HasMaxLength(1000);
        }
    }
}
