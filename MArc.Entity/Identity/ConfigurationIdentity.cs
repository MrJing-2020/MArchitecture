namespace MArc.Entity
{
    using MArc.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    public sealed class ConfigurationIdentity : DbMigrationsConfiguration<AppIdentityDbContext>
    {
        public ConfigurationIdentity()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MArc.Entity.AppIdentityDbContext";
        }

        protected override void Seed(AppIdentityDbContext context)
        {
            //AppUserManager userManager = new AppUserManager(new UserStore<AppUser>(context));
            //AppRoleManager roleManager = new AppRoleManager(new RoleStore<AppRole>(context));

            //string roleName = "Administrator";
            //string userName = "Admin";
            //string password = "Password2017";
            //string email = "794539959@qq.com";

            //if (!roleManager.RoleExists(roleName))
            //{
            //    roleManager.Create(new AppRole(roleName));
            //}

            //AppUser user = userManager.FindByName(userName);
            //if (user == null)
            //{
            //    userManager.Create(new AppUser { UserName = userName, Email = email },
            //        password);
            //    user = userManager.FindByName(userName);
            //}

            //if (!userManager.IsInRole(user.Id, roleName))
            //{
            //    userManager.AddToRole(user.Id, roleName);
            //}
        }
    }
}

