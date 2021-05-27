using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Content { get; set; }
        [Column(TypeName = "int")]
        public int? Time { get; set; }
        [DefaultValue(0)]
        [Column(TypeName = "int")]
        public int? FlagFinished { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        //public Exam Exam { get; set; }

    }
}
