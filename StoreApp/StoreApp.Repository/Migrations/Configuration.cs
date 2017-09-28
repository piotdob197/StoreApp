using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreApp.Context;
using StoreApp.Repository.Models;

namespace StoreApp.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreApp.Context.StoreAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StoreApp.Context.StoreAppContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
        }

        private void SeedUsers(StoreAppContext context)
        {

            var store = new UserStore<UserModel>(context);
            var manager = new UserManager<UserModel>(store);
            if (context.Users.Any(u => u.UserName == "Administrator")) return;
            var user = new UserModel { UserName = "Administrator", Email = "piotr.dobija94@gmail.com"};
            var adminresult = manager.Create(user, "Zaq12wsx!");
            if (adminresult.Succeeded)
            {
                manager.AddToRole(user.Id, "Admin");
            }
        }

        private void SeedRoles(StoreAppContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityRole role;

            if (!roleManager.RoleExists("Admin"))
            {
                role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("User"))
            {
                role = new IdentityRole { Name = "User" };
                roleManager.Create(role);
            }
          
        }
    }
}
