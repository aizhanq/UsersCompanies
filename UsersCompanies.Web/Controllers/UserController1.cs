using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersCompanies.DAL.Entities;
using UsersCompanies.Web.Models;
using UsersCompany.BLL.DTO;
using UsersCompany.BLL.Interfaces;
using UsersCompany.BLL.Services;

namespace UsersCompanies.Web.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService serv)
        {
            _userService = serv;
        }
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            IEnumerable<UserDTO> userDtos = await _userService.GetUsersAsync();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
            return View(users);
        }

        //public async Task<ActionResult<CompanyDTO>> GetCompanyById(int id)
        //{
        //    CompanyDTO company = await _userService.GetCompanyByIdAsync(id);

        //    if (company == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(company);
        //}

        //public ActionResult CreateCompany()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateCompany(CompanyViewModel company)
        //{
        //    var companyDTO = new CompanyDTO { Name = company.Name };
        //    await _companyService.CreateCompanyAsync(companyDTO);
        //    return Redirect("/Company/GetCompanies");
        //}

        //public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByCompanyId(int companyId)
        //{

        //    IEnumerable<UserDTO> userDtos = await _companyService.GetUsersByCompanyIdAsync(companyId);
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
        //    var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
        //    ;
        //    return View(users);
        //}
    }
}
