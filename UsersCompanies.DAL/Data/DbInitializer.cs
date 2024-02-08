using UsersCompanies.Domain.Entities;
using UsersCompanies.Domain.Repositories;

namespace UsersCompanies.DAL.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationContext context;

        public DbInitializer(ApplicationContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            context.Database.EnsureCreated();

            // Look for any users
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            Company company1 = new Company { Name = "Google" };
            Company company2 = new Company { Name = "Microsoft" };
            User user1 = new User { Name = "Tom", Age = 34, Company = company1 };
            User user2 = new User { Name = "Bob", Age = 25, Company = company2 };
            User user3 = new User { Name = "Sam", Age = 28, Company = company2 };
            Job job1 = new Job { Name = "Important job", Description = "Job for Tom from Google" };
            Job job2 = new Job { Name = "Another important job", Description = "Job for Sam and Bob from Microsoft" };
            Job job3 = new Job { Name = "Simple job", Description = "Simple job for Bob from Microsoft" };
            user1.Jobs.Add(job1);
            user2.Jobs.Add(job2);
            user2.Jobs.Add(job3);
            user3.Jobs.Add(job2);
            context.Companies.AddRange(company1, company2);
            context.Users.AddRange(user1, user2, user3);
            context.Jobs.AddRange(job1, job2, job3);
            context.SaveChanges();
        }
    }
}
