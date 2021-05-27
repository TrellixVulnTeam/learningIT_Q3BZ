using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.DTOs
{
    public class UserRankDetail
    {
        public int Id;
        public string FullName;
        public decimal Score;

        public UserRankDetail(int id, string fullName,decimal score)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Score = score;
        }
    }
}
