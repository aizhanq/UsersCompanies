using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersCompanies.DAL.Entities;
using UsersCompanies.Web.Models;
using UsersCompany.BLL.DTO;
using UsersCompany.BLL.Interfaces;
using UsersCompany.BLL.Services;

namespace UsersCompanies.Web.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService serv)
        {
            _companyService = serv;
        }
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            IEnumerable<CompanyDTO> companyDtos = await _companyService.GetCompaniesAsync();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CompanyDTO, CompanyViewModel>()).CreateMapper();
            var companies = mapper.Map<IEnumerable<CompanyDTO>, List<CompanyViewModel>>(companyDtos);
            return View(companies);
        }

        public async Task<ActionResult<CompanyDTO>> GetCompanyById(int id)
        {
            CompanyDTO company = await _companyService.GetCompanyByIdAsync(id);
            
            if(company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        public ActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyViewModel company)
        {
            var companyDTO = new CompanyDTO { Name = company.Name };
            await _companyService.CreateCompanyAsync(companyDTO);
            return Redirect("/Company/GetCompanies");
        }
    }
}
