using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Models;

namespace YuvamOl.Entity.Mappings
{
    public class GonulluOlMapping : EntityTypeConfiguration<GonulluOl>
    {
        public GonulluOlMapping()
        {
            Property(x => x.Ad).HasMaxLength(50);
            Property(x => x.Soyad).HasMaxLength(50);
            Property(x => x.Adres).HasMaxLength(500);
            Property(x => x.Telefon).HasMaxLength(10).HasColumnType("nchar");
            Property(x => x.EMail).HasMaxLength(100);
            Property(x => x.Notlar).HasMaxLength(1000);
        }
    }
}
