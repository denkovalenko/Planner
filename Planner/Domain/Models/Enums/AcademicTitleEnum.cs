using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum AcademicTitleEnum
    {
        [Display(Name = @"Доцент")]
        Docent=1,
        [Display(Name = @"Старший науковий співробітник")]
        SeniorResearchFellow,
        [Display(Name = @"Професор")]
        Professor
    }
}
