using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersCompanies.Web.Models;
using UsersCompanies.Domain.DTO;
using UsersCompanies.Domain.Services;
using NLog;

namespace UsersCompanies.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        ICompanyService _companyService;

        public CompanyController(ICompanyService serv, ILogger<CompanyController> logger)
        {
            _companyService = serv;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into CompanyController");
        }

        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            IEnumerable<CompanyDTO> companyDtos = await _companyService.GetCompaniesAsync();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CompanyDTO, CompanyViewModel>()).CreateMapper();
            var companies = mapper.Map<IEnumerable<CompanyDTO>, List<CompanyViewModel>>(companyDtos);

            _logger.LogInformation("Retrieved companies!");

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

        [HttpGet]
        public ActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyViewModel company)
        {
            if (company.Name == null) return View();
            var companyDTO = new CompanyDTO { Name = company.Name };
            await _companyService.CreateCompanyAsync(companyDTO);
            return Redirect("/Company/GetCompanies");
        }

        [HttpGet]
        public async Task<ActionResult> EditCompany(int id)
        {
            var companyDto = await _companyService.GetCompanyByIdAsync(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CompanyDTO, CompanyViewModel>()).CreateMapper();
            var company = mapper.Map<CompanyDTO, CompanyViewModel>(companyDto);
            return View(company);
        }

        [HttpPost]
        public async Task<ActionResult> EditCompany(CompanyDTO company)
        {
            if (company == null)
            {
                _logger.LogError("EditCompany: Company not found");
                return View(NotFound());
            }

            if (company.Name == null) return View();

            await _companyService.UpdateCompanyAsync(company);

            return Redirect("/Company/GetCompanies");
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            var existingEmployee = await _companyService.GetCompanyByIdAsync(id);

            if (existingEmployee == null)
            {
                _logger.LogError("DeleteCompany: Company not found");
                return View(NotFound());
            }

            await _companyService.DeleteCompanyAsync(id);

            return Redirect("/Company/GetCompanies");
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByCompanyId(int companyId)
        {
            _logger.LogDebug("Getting users by company ID");
            IEnumerable<UserDTO> userDtos = await _companyService.GetUsersByCompanyIdAsync(companyId);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
            _logger.LogDebug("Retrieved users by company ID");
            return View(users);
        }

        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobsByCompanyId(int companyId, string order = "Name")
        {
            _logger.LogDebug("Getting jobs by company ID");
            IEnumerable<JobDTO> jobDtos = await _companyService.GetJobsByCompanyIdAsync(companyId, order);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JobDTO, JobViewModel>()).CreateMapper();
            var jobs = mapper.Map<IEnumerable<JobDTO>, List<JobViewModel>>(jobDtos);
            ViewBag.companyId = companyId;
            _logger.LogDebug("Retrieved jobs by company ID");
            return View(jobs);
        }
    }
}
