using Microsoft.EntityFrameworkCore;
using UsersCompanies.DAL.Data;
using UsersCompanies.Domain.Entities;
using UsersCompanies.Domain.Repositories;

namespace UsersCompanies.DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationContext _context;
        public CompanyRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            return await _context.Companies.FindAsync(companyId);
        }

        public async Task CreateCompanyAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompanyAsync(int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetUsersByCompanyIdAsync(int companyId)
        {
            var users = await _context.Users
                .Where(u => u.CompanyId == companyId)
                .ToListAsync();

            return users;
        }

        public async Task<IEnumerable<Job>> GetJobsByCompanyIdAsync(int companyId)
        {
            var jobs = await _context.Users
                .Where(u => u.CompanyId == companyId)
                .SelectMany(u => u.Jobs)
                .Distinct()
                //.OrderBy(p => p.Name)
                .ToListAsync();

            return jobs;
        }
    }
}
