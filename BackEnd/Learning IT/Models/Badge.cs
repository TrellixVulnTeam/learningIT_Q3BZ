using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class Badge
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string ImageURL { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public IList<UserBadge> UserBadges { get; set; }
    }
}
