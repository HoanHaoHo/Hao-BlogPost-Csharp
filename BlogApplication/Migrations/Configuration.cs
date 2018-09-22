namespace BlogApplication.Migrations
{
    using BlogApplication.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogApplication.Models.ApplicationDbContext context)
        {
            
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Mod"))
            {
                roleManager.Create(new IdentityRole { Name = "Mod" });
            }
            
            if (!context.Users.Any(u => u.Email == "ho_hoan_hao94@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ho_hoan_hao94@yahoo.com",
                    Email = "ho_hoan_hao94@yahoo.com",
                    FirstName = "Hao",
                    LastName = "Ho",
                    DisplayName = "HaoHo"
                }, "Haomap6789@");
            }
            var adminId = userManager.FindByEmail("ho_hoan_hao94@yahoo.com").Id;
            userManager.AddToRole(adminId, "Admin");
            
            if (!context.Users.Any(u => u.Email == "hohoanhao94@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "hohoanhao94@gmail.com",
                    Email = "hohoanhao94@gmail.com",
                    FirstName = "Hoan",
                    LastName = "Hao",
                    DisplayName = "HoanHao"
                }, "Hohoanhao123456@");
            }
            
            var modId = userManager.FindByEmail("hohoanhao94@gmail.com").Id;
            userManager.AddToRole(modId, "Mod");
        }
    }
}
