using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UsersCompanies.DAL.EF;
using UsersCompanies.DAL.Entities;
using UsersCompanies.DAL.Interfaces;

namespace UsersCompanies.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;
        private CompanyRepository companyRepository;
        private UserRepository userRepository;
        private JobRepository jobRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IRepository<Company> Companies
        {
            get { return companyRepository ??= new CompanyRepository(_context); }
        }

        public IRepository<User> Users
        {
            get { return userRepository ??= new UserRepository(_context); }
        }

        public IRepository<Job> Jobs
        {
            get { return jobRepository ??= new JobRepository(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
