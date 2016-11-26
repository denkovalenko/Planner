using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; } 
        public String ThirdName { get; set; }
        public String PositionId { get; set; }
        public String DegreeId { get; set; }
        public String AcademicTitleId { get; set; }
		public String ScholarLink { get; set; }
		public String OrcidLink { get; set; }
		[ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

        public String ScheduleId { get; set; }
        [ForeignKey("DegreeId")]
        public virtual Degree Degree { get; set; }
       
        [ForeignKey("ScheduleId")]
         public virtual Schedule Schedule { get; set; }
        [ForeignKey("AcademicTitleId")]
        public virtual AcademicTitle AcademicTitle { get; set; }

        public String PlanRemarkId { get; set; }
        [ForeignKey("PlanRemarkId")]
        public virtual PlanRemark PlanRemark { get; set; }

        public String PlanConclusionId { get; set; }
        [ForeignKey("PlanConclusionId")]
        public virtual PlanConclusion PlanConclusion { get; set; }

        public String PlanChangeId { get; set; }
        [ForeignKey("PlanChangeId")]
        public virtual PlanChange PlanChange { get; set; }

        public String PlanAllocationId { get; set; }
        [ForeignKey("PlanAllocationId")]
        public virtual PlanAllocation PlanAllocation { get; set; }

        public virtual ICollection<DepartmentUser> DepartmentUsers { get; set; }
        public virtual ICollection<NDR> NDRs { get; set; }
        public virtual ICollection<PublicationUser> PublicationUser { get; set; }
        public virtual ICollection<ScientificPublishing> ScientificPublishings { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
