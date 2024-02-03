using Microsoft.AspNetCore.Mvc;
using UsersCompany.BLL.DTO;
using UsersCompany.BLL.Interfaces;
using UsersCompany.BLL.Services;

namespace UsersCompanies.Web.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService _companyService;
        public CompanyController(ICompanyService serv)
        {
            _companyService = serv;
        }
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            var employees = await _companyService.GetCompaniesAsync();
            return View(employees);
        }
    }
}
