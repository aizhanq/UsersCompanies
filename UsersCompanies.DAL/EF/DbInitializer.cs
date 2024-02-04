using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCompanies.DAL.Entities;
using UsersCompanies.DAL.Interfaces;

namespace UsersCompanies.DAL.EF
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
            Job job1 = new Job { Name = "Task for Tom in Google" };
            Job job2 = new Job { Name = "Task for Sam,Bom in Microsoft" };
            Job job3 = new Job { Name = "Task" };
            user1.Jobs.Add(job1);
            user2.Jobs.Add(job2);
            user3.Jobs.Add(job2);
            context.Companies.AddRange(company1, company2);
            context.Users.AddRange(user1, user2, user3);
            context.Jobs.AddRange(job1, job2, job3);
            context.SaveChanges();
        }
    }
}
