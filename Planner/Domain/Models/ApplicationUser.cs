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
		public String TimetableId { get; set; }
		public String ScholarLink { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        [ForeignKey("DegreeId")]
        public virtual Degree Degree { get; set; }
        [ForeignKey("AcademicTitleId")]
        public virtual AcademicTitle AcademicTitle { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUsers { get; set; }
        public virtual ICollection<PublicationUser> PublicationUser { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
