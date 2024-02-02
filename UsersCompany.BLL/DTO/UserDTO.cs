using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCompanies.DAL.Entities;

namespace UsersCompany.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }
    }
}
