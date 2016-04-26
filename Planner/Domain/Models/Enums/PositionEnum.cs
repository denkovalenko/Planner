using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum PositionEnum
    {
        [Display(Name = @"Завідуючий кафедрою")]
        HeadDepartment=1,
        [Display(Name = @"Доцент кафедрою")]
        DocentDepartment,
        [Display(Name = @"Старший викладач кафедри")]
        SeniorLecturer,
        [Display(Name = @"Викладач кафедри")]
        Lecturer,
        [Display(Name = @"Асистент")]
        Assistant
    }
}
