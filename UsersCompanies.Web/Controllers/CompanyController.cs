using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Diagnostics;
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

        [HttpGet]
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
                return View(NotFound());
            }

            await _companyService.UpdateCompanyAsync(company);

            return Redirect("/Company/GetCompanies");
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            var existingEmployee = await _companyService.GetCompanyByIdAsync(id);

            if (existingEmployee == null)
            {
                return View(NotFound());
            }

            await _companyService.DeleteCompanyAsync(id);

            return Redirect("/Company/GetCompanies");
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByCompanyId(int companyId)
        {
            IEnumerable<UserDTO> userDtos = await _companyService.GetUsersByCompanyIdAsync(companyId);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
            return View(users);
        }

        public async Task<ActionResult<IEnumerable<JobDTO>>> GetJobsByCompanyId(int companyId)
        {
            IEnumerable<JobDTO> jobDtos = await _companyService.GetJobsByCompanyIdAsync(companyId);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<JobDTO, JobViewModel>()).CreateMapper();
            var jobs = mapper.Map<IEnumerable<JobDTO>, List<JobViewModel>>(jobDtos);
            return View(jobs);
        }
    }
}
