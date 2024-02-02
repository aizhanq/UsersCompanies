using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCompany.BLL.DTO;

namespace UsersCompany.BLL.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> GetCompaniesAsync();
        Task<CompanyDTO> GetCompanyByIdAsync(int companyId);
        Task CreateCompanyAsync(CompanyDTO companyDTO);
        Task UpdateCompanyAsync(CompanyDTO companyDTO);
        Task DeleteCompanyAsync(int companyId);

        Task<IEnumerable<UserDTO>> GetUsersByCompanyIdAsync(int companyId);
    }
}
