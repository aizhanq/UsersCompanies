using UsersCompanies.DAL.Data;
using UsersCompanies.Domain.Repositories;

namespace UsersCompanies.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;
        private CompanyRepository companyRepository;
        private UserRepository userRepository;
        private JobRepository jobRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public ICompanyRepository Companies
        {
            get { return companyRepository ??= new CompanyRepository(_context); }
        }

        public IUserRepository Users
        {
            get { return userRepository ??= new UserRepository(_context); }
        }

        public IJobRepository Jobs
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
