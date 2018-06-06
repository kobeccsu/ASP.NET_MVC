using DemoMVC.LocalDbContext;
using DemoMVC.MemberShip;
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
    // follow this document that maybe realize it
    // https://www.cnblogs.com/calvinK/p/4648138.html
    public class AuthUtil
    {
        private static CustomUserManage GetManager()
        {
            var dbContext = new LocalDbContext.LocalDb();
            var userStore = new CustomUserStore(dbContext);
            //var userStore = new UserStore<IdentityUser>();

            //var a = new CustomUserManage(userStore);
            return new CustomUserManage(userStore);
        }

        public static bool SignIn(string username, string password, bool isPersistent)
        {
            var manager = GetManager();
            var user = manager.Find(username, password);


            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = isPersistent
                }, identity);
                return true;
            }
            return false;
        }

        public static void Register(string username, string password)
        {
            var manager = GetManager();
            var user = new CustomUser() { UserName = username };
            
            IdentityResult result = manager.Create(user, password);
            if (result.Succeeded)
            {
                SignIn(username, password, true);
            }
        }

        public static void SignOut()
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}