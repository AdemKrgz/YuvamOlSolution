using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YuvamOl.WebUI.Models.IdentityModels
{
    public class AppRole : IdentityRole
    {
        public AppRole()
        {

        }
        public AppRole(string roleName) : base(roleName)
        {

        }
    }
}