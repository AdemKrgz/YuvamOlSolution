using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YuvamOl.WebUI.Models.AccountModels;
using YuvamOl.WebUI.Models.IdentityModels;

namespace YuvamOl.WebUI.Controllers
{
    
    public class HesapController : Controller
    {
        private UserManager<AppUser> userManager;
        private RoleManager<AppRole> roleManager;
        private IdentityContext db;
        IdentityUserRole userRole;

        
        Regex harfRegex = new Regex(@"^[a-zA-Z]*$");
        Regex sayiRegex = new Regex(@"^[0-9]*$");
        Regex mailRegex = new Regex(@"^.+@[^\.].*\.[a-z]{2,}$");
        public HesapController()
        {
            db = new IdentityContext();
            UserStore<AppUser> userStore = new UserStore<AppUser>(db);
            userManager = new UserManager<AppUser>(userStore);
            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(db);
            roleManager = new RoleManager<AppRole>(roleStore);
        }
        #region Uyelik
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UyeOl(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser user = new AppUser
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        UserName = model.Username
                    };
                    IdentityResult iResult;
                    iResult = userManager.Create(user, model.Password);
                    if (iResult.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "User");
                        TempData["User"] = user;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["NoteError"] = "Kullanıcı ekleme işleminde hata! Lütfen alanlara girdiğiniz bilgilerin doğruluğunu kontrol ediniz.";
                        //ModelState.AddModelError("RegisterUser", "Kullanıcı ekleme işleminde hata!");
                    }
                }
                catch (System.Exception ex)
                {
                    TempData["NoteError"] = ex.Message;
                }
            }
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GirisYap(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser user = userManager.Find(model.Username, model.Password);
                    if (user != null)
                    {
                        IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                        ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                        AuthenticationProperties authProps = new AuthenticationProperties
                        {
                            IsPersistent = model.RememberMe
                        };
                        authManager.SignIn(authProps, identity);
                        TempData["NameSurname"] = user.Name + " " + user.Surname;

                        //rol teyiti
                        if (User.IsInRole("Admin"))
                        {
                            TempData["User"] = user;
                            return RedirectToAction("Index", "Admin/Admin");
                        }
                        else
                        {
                            TempData["User"] = user;
                            return RedirectToAction("Index", "Home");

                        }
                    }
                    else
                    {
                        TempData["NoteError"] = "Kullanıcı adı ya da şifre hatalı, lütfen tekrar deneyiniz.";
                    }
                }
                catch (System.Exception ex)
                {

                    TempData["NoteError"] = ex.Message;
                }
               
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Cikis()
        {
            var AuthenticationManager = ControllerContext.HttpContext.GetOwinContext().Authentication;

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Session.Abandon();
            Response.Cookies.Clear();
            return RedirectToAction("Index", "Home");
        }

        public AppUser KullaniciGetir(string userName)
        {
            
            return userManager.FindByName(userName);
        }
        #endregion
    }
}