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
        [Display(Name = @"Кандидат наук")]
        CandidateOfScience = 1,
        [Display(Name = @"Доктор наук")]
        DoctorOfScience
    }
}
