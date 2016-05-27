using Domain;
using Domain.Models;
using EfEnumToLookup.LookupGenerator;
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
            var enumToLookup = new EnumToLookup();
            enumToLookup.Apply(context);

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
                //userManager.AddToRole(admin.Id, role2.Name);
            }
            InitFaculties(context);
			InitNMBDs(context);
            base.Seed(context);

        }


		private void InitNMBDs(ApplicationDbContext context)
		{
			context.NMBDs.Add(new NMBD() { Name = "SCOPUS" });
			context.NMBDs.Add(new NMBD() { Name = "Web of Science" });
			context.NMBDs.Add(new NMBD() { Name = "Index Copernicus" });
			context.NMBDs.Add(new NMBD() { Name = "Thomson" }); 

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
                  new Department() {Name="Кафедра інформаційних систем",Schedules=new List<Schedule>() {
                         new Schedule() {UserName="Алексієв Володимир Олегович",ApiId="352974" },
                         new Schedule() {UserName="Анохін Віктор Миколайович",ApiId="335091" },
                         new Schedule() {UserName="Арзубов Микола Олексійович",ApiId="357453" },
                         new Schedule() {UserName="Безсонов Олександр Олександрович",ApiId="358250" },
                         new Schedule(){UserName="Беседовський Олексій Миколайович",ApiId="354067" },
                         new Schedule(){UserName="Біккузін Кирило Валерійович",ApiId="353049" },
                         new Schedule(){UserName="Бурдаєв Володимир Петрович",ApiId="352259" },
                         new Schedule(){UserName="Воропай Наталя Ігорівна",ApiId="340168" },
                         new Schedule(){UserName="Гаврилова Алла Андріївна",ApiId="352978" },
                         new Schedule(){UserName="Гниря Аліна Вікторівна",ApiId="352545" },
                         new Schedule(){UserName="Голубничий Дмитро Юрійович",ApiId="352425" },
                         new Schedule(){UserName="Гриньов Денис Валерійович",ApiId="354072" },
                         new Schedule(){UserName="Дорохов Олександр Васильович",ApiId="342922" },
                         new Schedule(){UserName="Євсеєв Сергій Петрович",ApiId="340599" },
                         new Schedule(){UserName="Задачин Віктор Михайлович",ApiId="357259" },
                         new Schedule(){UserName="Зінчук Антон Владиславович",ApiId="354105" },
                         new Schedule(){UserName="Знахур Людмила Володимирівна",ApiId="344463" },
                         new Schedule(){UserName="Знахур Сергій Вікторович",ApiId="354076" },
                         new Schedule(){UserName="Золотарьова Ірина Олександрівна",ApiId="354077" },
                         new Schedule(){UserName="Коваленко Андрій Анатолійович",ApiId="357156"},
                         new Schedule(){UserName="Конюшенко Ірина Григорівна",ApiId="354082"},
                         new Schedule(){UserName="Король Ольга Григорівна",ApiId="353052"},
                         new Schedule(){UserName="Коц Григорій Павлович",ApiId="352373"},
                         new Schedule(){UserName="Лагутін Максим Ігорович",ApiId="352388"},
                         new Schedule(){UserName="Лосєв Михайло Юрійович",ApiId="340607"},
                         new Schedule(){UserName="Макарова Ганна Валеріївна",ApiId="354101"},
                         new Schedule(){UserName="Мінухін Сергій Володимирович",ApiId="352969"},
                         new Schedule(){UserName="Огурцов Віталій Вячеславович",ApiId="357267"},
                         new Schedule(){UserName="Парфьонов Юрій Едуардович",ApiId="354098"},
                         new Schedule(){UserName="Плеханова Ганна Олегівна",ApiId="354099"},
                         new Schedule(){UserName="Плоха Олена Борисівна",ApiId="354100" },
                         new Schedule(){UserName="Поляков Андрій Олександрович",ApiId="357262" },
                         new Schedule(){UserName="Пономаренко Володимир Степанович",ApiId="357123" },
                         new Schedule(){UserName="Руденко Олег Григорійович",ApiId="357771" },
                         new Schedule(){UserName="Савін Юрій Вікторович",ApiId="357270"},
                         new Schedule(){UserName="Северин Валерій Петрович",ApiId="357760"},
                         new Schedule(){UserName="Сидоренко Іван Григорович",ApiId="354089"},
                         new Schedule(){UserName="Скорін Юрій Іванович",ApiId="352775"},
                         new Schedule(){UserName="Тарасов Олександр Васильович",ApiId="354090"},
                         new Schedule(){UserName="Ткачов Віталій Миколайович",ApiId="357159"},
                         new Schedule(){UserName="Ушакова Ірина Олексіївна",ApiId="340598"},
                         new Schedule(){UserName="Федорченко Володимир Миколайович",ApiId="297080"},
                         new Schedule(){UserName="Федько Віктор Васильович",ApiId="357266"},
                         new Schedule(){UserName="Фесенко Микола Сергійович",ApiId="348370"},
                         new Schedule(){UserName="Холодкова Анна Валеріївна",ApiId="306111"},
                         new Schedule(){UserName="Шматко Олександр Віталійович",ApiId="352265"},
                         new Schedule(){UserName="Щербаков Олександр Всеволодович",ApiId="354088"},
                         new Schedule(){UserName="Щербаков Олександр Всеволодович",ApiId="354088"},
                     } },
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
                    new Department() {Name="Кафедра іноземних мов та перекладу",Schedules=new List<Schedule>() {
                         new Schedule() {UserName="Алексєєва Марія Ігорівна",ApiId="315221" },
                         new Schedule() {UserName="Безугла Ірина Валентинівна",ApiId="354065" },
                         new Schedule() {UserName="Гончарова Жанна Миколаївна",ApiId="341277" },
                         new Schedule() {UserName="Григор'єв Максим Вікторович",ApiId="354104" },
                         new Schedule(){UserName="Давидова Жанна Вадимівна",ApiId="336075" },
                         new Schedule(){UserName="Євдокімова-Лисогор Леся Анатоліївна",ApiId="354074" },
                         new Schedule(){UserName="Єрастова-Михалусь Інна Борисівна",ApiId="354074" },
                         new Schedule(){UserName="Іваніга Орина Валеріївна",ApiId="314908" },
                         new Schedule(){UserName="Ігнатенко Лариса Олександрівна",ApiId="340637" },
                         new Schedule(){UserName="Камишнікова Яна Сергіївна",ApiId="307719" },
                         new Schedule(){UserName="Кобринець Ольга Станіславівна",ApiId="307718" },
                         new Schedule(){UserName="Коваль Аліна Сергіївна",ApiId="352834" },
                         new Schedule(){UserName="Колбіна Тетяна Василівна",ApiId="290422" },
                         new Schedule(){UserName="Курінна Світлана Дмитрівна",ApiId="352908" },
                         new Schedule(){UserName="Лукашова Людмила Василівна",ApiId="319066" },
                         new Schedule(){UserName="Луніна Марина Леонідівна",ApiId="352735" },
                         new Schedule(){UserName="Лютвієва Ярослава Павлівна",ApiId="352511" },
                         new Schedule(){UserName="Михайлова Людмила Зіновіївна",ApiId="305968" },
                         new Schedule(){UserName="Нікішина Анжела Володимирівна",ApiId="335080" },
                         new Schedule(){UserName="Олексенко Олена Олексіївна",ApiId="352336"},
                         new Schedule(){UserName="Прус Наталія Олексіївна",ApiId="354754"},
                         new Schedule(){UserName="Решетняк Ірина Олексіївна",ApiId="283055"},
                         new Schedule(){UserName="Савицька Лариса Володимирівна",ApiId="354594"},
                        new Schedule(){UserName="Сальтевська Марина Юхимівна",ApiId="334839"},
                         new Schedule(){UserName="Тарасенко Сергій Євгенович",ApiId="353099"},
                         new Schedule(){UserName="Хачатрян Єва Левонівна",ApiId="355171"},
                         new Schedule(){UserName="Хоменко Вікторія Володимирівна",ApiId="352907"},
                         new Schedule(){UserName="Ципіна Діана Савеліївна",ApiId="355206"},
                         new Schedule(){UserName="Черниш Людмила Миколаївна",ApiId="329114"},
                         new Schedule(){UserName="Черниш Людмила Миколаївна",ApiId="329114"}
                     } },
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