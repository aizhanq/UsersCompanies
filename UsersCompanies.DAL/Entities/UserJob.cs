using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersCompanies.DAL.Entities
{
    public class UserJob
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
    }
}
