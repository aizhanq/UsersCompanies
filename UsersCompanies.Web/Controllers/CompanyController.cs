using Microsoft.AspNetCore.Mvc;
using UsersCompany.BLL.DTO;
using UsersCompany.BLL.Interfaces;
using UsersCompany.BLL.Services;

namespace UsersCompanies.Web.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService companyService;
        public CompanyController(ICompanyService serv)
        {
            companyService = serv;
        }       
    }
}
