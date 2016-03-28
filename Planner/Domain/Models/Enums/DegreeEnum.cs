using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum DegreeEnum
    {
        [Display(Name = @"Кандидат наук")]
        CandidateOfScience,
        [Display(Name = @"Доктор наук")]
        DoctorOfScience
    }
}
