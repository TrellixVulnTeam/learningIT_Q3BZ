using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(36)")]
        public string Type { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Description { get; set; }
        
        public virtual IList<UserRole> UserRoles { get; set; }

    }
}
