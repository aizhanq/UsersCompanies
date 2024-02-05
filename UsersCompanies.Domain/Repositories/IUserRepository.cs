using UsersCompanies.Domain.Entities;

namespace UsersCompanies.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        //Task<IEnumerable<Job>> GetJobsByUserIdAsync(int id);
    }
}
