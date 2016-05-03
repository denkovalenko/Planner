using Domain;
using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace Planner
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        /// <summary>
        /// Add default user
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create two role
            var role1 = new IdentityRole { Name = "Admin" };
            var role2 = new IdentityRole { Name = "User" };

            // Add role to db
            roleManager.Create(role1);
            roleManager.Create(role2);

            // Create users
            var admin = new ApplicationUser { Email = "administrator@gmail.com", UserName = "administrator@gmail.com" };
            string password = "Administrator123123!!!";
            var result = userManager.Create(admin, password);

            // Success
            if (result.Succeeded)
            {
                // Add role for user
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            InitFaculties(context);
            InitScientificBases(context);
            base.Seed(context);
        }

        private void InitScientificBases(ApplicationDbContext context)
        {
            context.ScientificBases.Add(new ScientificBase() { Name = "Google Scholar" });
            context.ScientificBases.Add(new ScientificBase() { Name = "ORCID" });
            base.Seed(context);
        }
        private void InitFaculties(ApplicationDbContext context)
        {
            List<Faculty> f = new List<Faculty>();
            f.Add(new Faculty()
            {
                Name = "Факультет консалтингу i мiжнародного бiзнесу",
                Departments = new List<Department>()
                {
                    new Department() {Name="Кафедра бухгалтерського облiку" },
                    new Department() {Name="Кафедра економiчного аналiзу" },
                    new Department() {Name="Кафедра вищої математики та оцiнки майна пiдприємств" },
                    new Department() {Name="Кафедра контролю i аудиту" },
                    new Department() {Name="Кафедра філософії та політології" }
                }
            });
            f.Add(new Faculty()
            {
                Name = "Факультет фінансовий",
                Departments = new List<Department>()
                {
                    new Department() {Name="Кафедра фінансів" },
                    new Department() {Name="Кафедра управління фінансовими послугами" },
                    new Department() {Name="Кафедра банківськоі справи" },
                    new Department() {Name="Кафедра оподаткування" }
                }
            });
            f.Add(new Faculty()
            {
                Name = "Факультет менеджменту і маркетингу",
                Departments = new List<Department>()
                {
                    new Department() {Name="Кафедра менеджменту" },
                    new Department() {Name="Кафедра менеджменту і бізнесу" },
                    new Department() {Name="Кафедра економіки, організації та планування діяльності підприємства" },
                    new Department() {Name="Кафедра економіки і маркетингу" }
                }
            });
            f.Add(new Faculty()
            {
                Name = "Факультет економічної інформатики",
                Departments = new List<Department>()
                {
                    new Department() {Name="Кафедра інформаційних систем" },
                    new Department() {Name="Кафедра економічної кібернетики" },
                    new Department() {Name="Кафедра технології, екології та безпеки життєдіяльності" },
                    new Department() {Name="Кафедра комп'ютерних систем і технологій" },
                    new Department() {Name="Кафедра інформатики та комп'ютерної техніки" },
                    new Department() {Name="Кафедра статистики та економічного прогнозування" }
                }
            });
            f.Add(new Faculty()
            {
                Name = "Факультет економіки і права",
                Departments = new List<Department>()
                {
                    new Department() {Name="Кафедра управління персоналом та економіки праці" },
                    new Department() {Name="Кафедра економіки підприємств і менеджменту" },
                    new Department() {Name="Кафедра соціології та психології управління" },
                    new Department() {Name="Кафедра правового регулювання економіки" },
                    new Department() {Name="Кафедра державного управління, публічного адміністрування та регіональної економіки" },
                    new Department() {Name="Кафедра управління соціальними комунікаціями" },
                      new Department() {Name="Кафедра педагогіки та іноземноі філології" },
                }
            });
            f.Add(new Faculty()
            {
                Name = "Факультет міжнародних економічних відносин",
                Departments = new List<Department>()
                {
                    new Department() {Name="Кафедра міжнародної економіки та менеджменту зовнішньоекономічної діяльності" },
                    new Department() {Name="Кафедра політичної економії" },
                    new Department() {Name="Кафедра іноземних мов та перекладу" },
                    new Department() {Name="Кафедра туризму" },
                }
            });
            f.Add(new Faculty()
            {
                Name = "Факультет підготовки іноземних громадян",
                Departments = new List<Department>()
                {
                    new Department() {Name="Кафедра українознавства і мовної підготовки іноземних громадян" },
                    new Department() {Name="Кафедра природничих наук та технології" },
                    new Department() {Name="Кафедра фізвиховання та спорту" }
                }
            });
            foreach (var item in f)
            {
                context.Faculties.Add(item);
            }
        }
    }
}