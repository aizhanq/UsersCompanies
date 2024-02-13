using UsersCompanies.Domain.Entities;

namespace UsersCompanies.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task CreateCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
        Task<IEnumerable<User>> GetUsersByCompanyIdAsync(int id);
        Task<IEnumerable<Job>> GetJobsByCompanyIdAsync(int companyId, string order);
    }
}
