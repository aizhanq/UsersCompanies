using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCompanies.DAL.Entities;
using UsersCompanies.DAL.Interfaces;
using UsersCompany.BLL.DTO;
using UsersCompany.BLL.Interfaces;

namespace UsersCompany.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _unitOfWork.Users.GetUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task CreateUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _unitOfWork.Users.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var existingUser = await _unitOfWork.Users.GetUserByIdAsync(userDTO.Id);

            if (existingUser == null)
            {
                // Handling the situation if a user with the specified ID is not found
                throw new ValidationException("User not found");
            }

            // AutoMapper для копирования значений из companyDTO в existingCompany
            _mapper.Map(userDTO, existingUser);

            await _unitOfWork.Users.UpdateUserAsync(existingUser);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _unitOfWork.Users.DeleteUserAsync(userId);
        }

        //public async Task<IEnumerable<JobDTO>> GetJobsByUserIdAsync(int userId)
        //{
        //    var jobs = await _unitOfWork.Users.GetJobsByUserIdAsync(userId);
        //    return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        //}
    }
}
