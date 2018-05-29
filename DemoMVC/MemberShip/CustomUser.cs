using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.MemberShip
{
    public class CustomUser : IdentityUser<string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUser, IUser<string>
    {
        public string Id { get { return this.Id; } } 

        //public string UserName { get { return this.UserName; } set { this.UserName = value; } }
    }
}