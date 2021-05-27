using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }  
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? ImageURL { get; set; }
    }
}
