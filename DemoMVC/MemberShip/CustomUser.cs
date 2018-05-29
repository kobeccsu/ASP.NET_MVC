using DemoMVC.LocalDbContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.MemberShip
{
    public class CustomUser : IdentityUser, IUser<string>
    {
         string IUser<string>.Id { get { return this.Id.ToString(); } }
    }
}