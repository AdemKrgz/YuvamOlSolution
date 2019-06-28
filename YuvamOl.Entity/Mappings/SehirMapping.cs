using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.Entity.Mappings
{
    public class SehirMapping : EntityTypeConfiguration<Sehir>
    {
        public SehirMapping()
        {
            Property(x => x.Ad).HasMaxLength(50);
        }
    
    }
}
