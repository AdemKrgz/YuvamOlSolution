using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using YuvamOl.WebUI.Models.Configurations;

namespace YuvamOl.WebUI.Models.IdentityModels
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext() 
        {
            #region Kutaycan

            //Database.Connection.ConnectionString = @"Server=WISSEN\MSSQL2017;Database=YuvamOlDb;UID=sa;PWD=12345";
            Database.Connection.ConnectionString = @"Server=KUTAYCAN\KUTAYMSSQLSERVER;Database=YuvamOlDb;UID=sa;PWD=12345";
            #endregion

            #region Adem
            //Database.Connection.ConnectionString = @"server=PC-BILGISAYAR\WINCCPLUSMIG2014; database = YuvamOlDb; integrated security = True";
            //Database.Connection.ConnectionString = @"Server=WISSEN-PC\MSSQLSRV;Database=YuvamOlDb;UID=sa;PWD=12345";
            #endregion

            #region Eshat
            //Database.Connection.ConnectionString = @"server=ESHAT\SQLEXPRESS; database=YuvamOlDB; integrated security=true";

            //Database.Connection.ConnectionString = 
            #endregion

            System.Data.Entity.Database.SetInitializer(new IdentityContextInitializer());
        }
        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}