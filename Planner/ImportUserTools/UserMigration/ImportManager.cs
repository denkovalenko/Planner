
using Domain;
using Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportUserTools.UserMigration
{
    static class ImportManager
    {
        public static Boolean UpdateDbFormExcel()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            Console.WriteLine("База открыта:");
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "ExcelFolder", "users.xlsx");
            SLDocument sl = new SLDocument(path, "Лист1");
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            Console.WriteLine("Документ users открыт:");

            for (int row = 1; row < stats.EndRowIndex; row++)
            {
                var Id = sl.GetCellValueAsString(row, 1);
                var lastName = sl.GetCellValueAsString(row, 2);
                var firstName = sl.GetCellValueAsString(row, 3);
                var thirdName = sl.GetCellValueAsString(row, 4);
                //кафедра
                var department = sl.GetCellValueAsString(row, 5);
                var basicOrCompatible = sl.GetCellValueAsString(row, 8);
                var phone = sl.GetCellValueAsString(row, 9);
                var email = sl.GetCellValueAsString(row, 10);
                var document = sl.GetCellValueAsString(row, 13);
                if (userManager.Users.Where(x => x.Email == email).Any())
                    continue;
            }
            return false;
        }

    }
}
