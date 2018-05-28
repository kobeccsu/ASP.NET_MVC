using DemoMVC.LocalDbContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DemoMVC.Util
{
    public class AuthUtil
    {
        public static void SignInAsync(string username, string password, bool isPersistent)
        {
            var dbContext = new LocalDbContext.LocalDb();
            var userStore = new UserStore<IdentityUser>(dbContext);
            var manager = new UserManager<IdentityUser>(userStore);
            var user = manager.Find(username, password);

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var identity = manager.CreateIdentity<IdentityUser, string>(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties()
               {
                   IsPersistent = isPersistent
               }, identity);
        }

        public static void Register(string username, string password)
        {
            var dbContext = new LocalDbContext.LocalDb();
            var userStore = new UserStore<IdentityUser>(dbContext);
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = username };
            
            IdentityResult result = manager.Create<IdentityUser, string>(user, password);
            if (result.Succeeded)
            {
                SignInAsync(username, password, true);
            }
        }

        public static void SignOut()
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}