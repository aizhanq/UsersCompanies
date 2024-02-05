using UsersCompanies.Domain.DTO;

namespace UsersCompanies.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task CreateUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(UserDTO userDTO);
        Task DeleteUserAsync(int userId);
        //Task<IEnumerable<JobDTO>> GetJobsByUserIdAsync(int userd);
    }
}
