using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string IdentityId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string LastName { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public Decimal Score { get; set; }
        public string Image { get; set; }
        public virtual IList<UserRole> UserRoles { get; set; }
        public virtual IList<Article> Articles { get; set; }
        public virtual IList<UserCourse> UserCourses { get; set; }
        public IList<UserBadge> UserBadges { get; set; }

    }
}
