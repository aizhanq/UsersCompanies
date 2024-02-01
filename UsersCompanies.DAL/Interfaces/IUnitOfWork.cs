using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UsersCompanies.DAL.Entities;

namespace UsersCompanies.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Company> Companies { get; }
        IRepository<User> Users { get; }
        IRepository<Job> Jobs { get; }

        Task<int> SaveChangesAsync();
    }
}
