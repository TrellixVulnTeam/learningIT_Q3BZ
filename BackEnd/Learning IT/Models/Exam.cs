using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "varchar(256)")]
        public string Content { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public Decimal Points { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public virtual IList<QuestionExam> QuestionExams { get; set; }


    }
}
