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
    }
}
