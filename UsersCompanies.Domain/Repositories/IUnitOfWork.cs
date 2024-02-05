namespace UsersCompanies.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        IJobRepository Jobs { get; }

        Task<int> SaveChangesAsync();
    }
}
