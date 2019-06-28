using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YuvamOl.WebUI.Models.IdentityModels;

namespace YuvamOl.WebUI.Models.Configurations
{
    public class IdentityContextInitializer : DropCreateDatabaseIfModelChanges<IdentityContext>
    {
        protected override void Seed(IdentityContext context)
        {
            context.Roles.Add(new AppRole { Name = "Admin", Id = Guid.NewGuid().ToString() });
            context.Roles.Add(new AppRole { Name = "User", Id = Guid.NewGuid().ToString() });
            context.SaveChanges();
        }
    }
}