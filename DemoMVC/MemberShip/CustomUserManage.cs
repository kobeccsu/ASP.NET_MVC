using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.MemberShip
{
    public class CustomUserManage : UserManager<CustomUser, string>  
    {
        public CustomUserManage(IUserStore<CustomUser> store) : base(store)
        {

        }

        

    }
}