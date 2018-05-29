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

            var a = new CustomUserManage(userStore);
            return new CustomUserManage(userStore);
        }

        public async static void SignInAsync(string username, string password, bool isPersistent)
        {
            var manager = GetManager();
            var user = manager.Find(username, password);

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var identity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties()
               {
                   IsPersistent = isPersistent
               }, identity);
        }

        public static async void Register(string username, string password)
        {
            var manager = GetManager();
            var user = new CustomUser() { UserName = username };
            
            IdentityResult result = await manager.CreateAsync(user, password);
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