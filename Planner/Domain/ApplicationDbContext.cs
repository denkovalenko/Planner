﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Domain.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<AcademicTitle> AcademicTitles { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Rate> Rates { get; set; }
		public DbSet<ExternalCollaborator> ExternalCollaborators { get; set; }
		public DbSet<StoringType> StoringTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<PlanRemark> PlanRemarks { get; set; }
        public DbSet<PlanConclusion> PlanConclusions { get; set; }
        public DbSet<PlanChange> PlanChanges { get; set; }
        public DbSet<PlanManagment> PlanManagments { get; set; }
        public DbSet<PlanScientificWork> PlanScientificWorks { get; set; }
        public DbSet<PlanMethodicalWork> PlanMethodicalWorks { get; set; }
        public DbSet<PlanAllocation> PlanAllocations { get; set; }
        public DbSet<PlanTrainingJob> PlanTrainingJobs { get; set; }
        public DbSet<ResearchDoneType> ResearchDoneTypes { get; set; }
		public DbSet<NMBD> NMBDs { get; set; }
        public DbSet<ScientificPublishing> ScientificPublishings { get; set; }


        public DbSet<PublicationNMBD> PublicationNMBDs { get; set; }
		public DbSet<PublicationUser> PublicationUsers { get; set; }
		public DbSet<DepartmentUser> DepartmentUsers { get; set; }

		public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }
}