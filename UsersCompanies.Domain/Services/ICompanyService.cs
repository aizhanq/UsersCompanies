using UsersCompanies.Domain.DTO;

namespace UsersCompanies.Domain.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetCompaniesAsync();
        Task<CompanyDTO> GetCompanyByIdAsync(int companyId);
        Task CreateCompanyAsync(CompanyDTO companyDTO);
        Task UpdateCompanyAsync(CompanyDTO companyDTO);
        Task DeleteCompanyAsync(int companyId);
        Task<IEnumerable<UserDTO>> GetUsersByCompanyIdAsync(int companyId);
        Task<IEnumerable<JobDTO>> GetJobsByCompanyIdAsync(int companyId);
    }
}
