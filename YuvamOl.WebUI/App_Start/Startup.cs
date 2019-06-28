using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using YuvamOl.BLL.Concretes.TanimService;
using YuvamOl.WebUI.Models.IdentityModels;


[assembly: OwinStartup(typeof(YuvamOl.WebUI.App_Start.Startup))]

namespace YuvamOl.WebUI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                ExpireTimeSpan = System.TimeSpan.FromMinutes(5),
                CookieName = "user",
                LoginPath = new PathString("/Hesap/GirisYap"),
                LogoutPath = new PathString("/Hesap/CikisYap")
            });

            //createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            IdentityContext context = new IdentityContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new AppUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                string userPWD = "123456";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating User role     
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
        }

        //private void TurEkle()
        //{
        //    TurService turService = new TurService();
        //}
    }
}
