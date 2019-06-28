using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.Entity.Mappings;
using YuvamOl.Entity.Models;

namespace YuvamOl.DAL.DbContexts
{
    public class YuvamOlDbContext : DbContext
    {
        public YuvamOlDbContext()
        {
            #region Kutaycan

            //Database.Connection.ConnectionString = @"Server=WISSEN-PC\MSSQLSRV;Database=YuvamOlDb;UID=sa;PWD=12345";
            //Database.Connection.ConnectionString = @"Server=KUTAYCAN\KUTAYMSSQLSERVER;Database=YuvamOlDb;UID=sa;PWD=12345";
            #endregion

            #region Adem
            //Database.Connection.ConnectionString = @"Server=WISSEN-PC\MSSQLSRV;Database=YuvamOlDb;UID=sa;PWD=12345";
            Database.Connection.ConnectionString = @"server=PC-BILGISAYAR\WINCCPLUSMIG2014; database = YuvamOlDb; integrated security = True";
            #endregion

            #region Eshat
            //Database.Connection.ConnectionString = @"server=ESHAT\SQLEXPRESS; database=YuvamOlDB; integrated security=true";

            //Database.Connection.ConnectionString = 
            #endregion

        }

        #region Entites
        public DbSet<BizeUlasin> BizeUlasin { get; set; }
        public DbSet<Cins> Cins { get; set; }
        public DbSet<GaleriFotograf> GaleriFotograf { get; set; }
        public DbSet<Ilan> Ilan { get; set; }
        public DbSet<IlanDetay> IlanDetay { get; set; }
        public DbSet<IlanFotograf> IlanFotograf { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<GonulluOl> GonulluOl { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new BizeUlasinMapping());
            modelBuilder.Configurations.Add(new CinsMapping());
            modelBuilder.Configurations.Add(new GaleriFotografMapping());
            modelBuilder.Configurations.Add(new IlanDetayMapping());
            modelBuilder.Configurations.Add(new IlanFotografMapping());
            modelBuilder.Configurations.Add(new IlanMapping());
            modelBuilder.Configurations.Add(new IlceMapping());
            modelBuilder.Configurations.Add(new SehirMapping());
            modelBuilder.Configurations.Add(new TurMapping());
            modelBuilder.Configurations.Add(new GonulluOlMapping());
        }
    }
}
