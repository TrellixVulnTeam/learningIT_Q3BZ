using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class QuestionExam
    {
        [Key,Column(Order = 1)]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        [Key,Column(Order = 2)]
        public int  ExamId { get; set; }
        public Exam Exam { get; set; }

    }
}
