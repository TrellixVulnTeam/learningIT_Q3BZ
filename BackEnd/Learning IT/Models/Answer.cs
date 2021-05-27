using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Content { get; set; }

        public IList<AnswerQuestion> AnswerQuestions { get; set; }
    }
}
