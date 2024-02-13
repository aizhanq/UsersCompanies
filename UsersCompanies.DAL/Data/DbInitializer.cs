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
            context.Database.EnsureDeleted();
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
            var jobs = new Job[] {
                new Job { Name = "Package and store finished product", Description = "Job for Tom from Google" },
                new Job { Name = "Very important job", Description = "Job for Sam and Bob from Microsoft" },
                new Job { Name = "Simple job", Description = "Simple job for Bob from Microsoft" },
                new Job { Name = "Order supplies and materials", Description = "Order supplies and materials as needed" },
                new Job { Name = "Track accounts", Description = "Track accounts payable and accounts receivable" },
                new Job { Name = "Feedbacks", Description = "Receive and respond to customer feedback" }
            };
            user1.Jobs.Add(jobs[0]);
            user1.Jobs.Add(jobs[3]);
            user2.Jobs.Add(jobs[2]);
            user2.Jobs.Add(jobs[3]);
            user2.Jobs.Add(jobs[1]);
            user3.Jobs.Add(jobs[2]);
            user3.Jobs.Add(jobs[4]);
            user3.Jobs.Add(jobs[5]);
            context.Companies.AddRange(company1, company2);
            context.Users.AddRange(user1, user2, user3);
            context.Jobs.AddRange(jobs);
            context.SaveChanges();
        }
    }
}
