using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class UserBadge
    {
        [Key, Column(Order = 1)]
        public int UserID { get; set; }
        public User User { get; set; }
        [Key, Column(Order = 2)]
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
    }
}
