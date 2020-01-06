using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebApplication1.Models;

namespace WebApplication1.App_Start
{
    public class IdentityConfig
    {
        public class ApplicationUserManager : UserManager<AppUser>
        {
            public ApplicationUserManager(IUserStore<AppUser> store)
                : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                IOwinContext context)
            {
                var manager =
                    new ApplicationUserManager(new UserStore<AppUser>(context.Get<MyDbContext>()));
                return manager;
            }
        }
    }
}