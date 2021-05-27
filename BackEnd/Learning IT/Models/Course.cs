using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class Course
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Description { get; set;}
        [Column(TypeName = "nvarchar(max)")]
        public string ImageURL { get; set; }
        [Column(TypeName = "int")]
        public int? Experience {get;set;}
        [Column(TypeName = "nvarchar(max)")]
        public string? Category { get;set;}
        [Column(TypeName = "nvarchar(max)")] 
        public string? Level { get; set; }
        [Column(TypeName = "int")]
        public int? Time { get; set; }
        public Badge Badge { get; set; }
        public Exam Exam { get; set; }

        public virtual IList<UserCourse> UserCourses { get; set; }
        public virtual IList<Chapter> Chapters { get; set; }
    }
}
