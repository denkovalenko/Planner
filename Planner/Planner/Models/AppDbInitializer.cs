using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Planner.Models;
using System.Data.Entity;

namespace Planner
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        /// <summary>
        /// Add default user
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ApplicationDbContext context)
        {  
            //Create default user/admin
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create two role
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // Add role to db
            roleManager.Create(role1);
            roleManager.Create(role2);

            // Create users
            var admin = new ApplicationUser { Email = "sanyaaxel94@gmail.com", UserName = "SanyaAxel" };
            string password = "Aa123987!!!";
            var result = userManager.Create(admin, password);

            // Success
            if (result.Succeeded)
            {
                // Add role for user
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            base.Seed(context);
        }
    }
}