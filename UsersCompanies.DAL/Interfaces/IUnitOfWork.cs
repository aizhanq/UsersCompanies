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
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        IJobRepository Jobs { get; }

        Task<int> SaveChangesAsync();
    }
}
