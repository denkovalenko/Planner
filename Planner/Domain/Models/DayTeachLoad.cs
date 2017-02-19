﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class DayTeachLoad
    {
        public DayTeachLoad()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public String Id { get; set; }

        public int Semester { get; set; }
        public string Specialty { get; set; }
        public double Course { get; set; }
        public double Lecture { get; set; }
        public double Practice { get; set; }
        public double Lab { get; set; }
        public double ConsultInSemester { get; set; }
        public double ConsultForExam { get; set; }
        public double WrittenWork { get; set; }
        public double CalcWorks { get; set; }
        public double CourseProjects { get; set; }
        public double Evaluation { get; set; }
        public double OralExam { get; set; }
        public double WrittenExam { get; set; }
        public double VerifyingOfTest { get; set; }
        public double ManagedDiploma { get; set; }
        public double Dek { get; set; }
        public double VerifyingOfWrittenWorks { get; set; }
        public double Protection { get; set; }
        public double Total { get; set; }
        public double Active { get; set; }

        public String SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public String DayEntryLoadId { get; set; }
        [ForeignKey("DayEntryLoadId")]
        public virtual DayEntryLoad DayEntryLoad { get; set; }

        // as Teacher
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}