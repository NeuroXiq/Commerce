using Commerce.Data;
using Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.InitStartup
{
    public class SeedDatabase
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new CommerceDbContext(serviceProvider.GetRequiredService<DbContextOptions<CommerceDbContext>>()))
            {
                if (context.Contractors.Count() < 10)
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        AddContractors(context);
                    }

                    context.SaveChanges();
                }
            }
        }

        private static void AddContractors(CommerceDbContext context)
        {
            Contractor c = new Contractor();

            c.FirstName = RandString();
            c.LastName = RandString();
            c.BankAccountNumber = RandString(15, 15);
            c.City = RandString();
            c.Country = RandString();
            c.Email = RandString() + "@" + RandString(2, 4) + "." + RandString(2, 4);
            c.NBRN = RandString(15, 15);
            c.Street = RandString();
            c.TaxNumber = RandString(9, 9);

            context.Add(c);
        }

        static Random random = new Random();
        static string RandString(int min = 3, int max = 15)
        {
            string result = "";
            int len = random.Next(min,max);

            for (int i = 0; i < len; i++)
            {
                int rand = random.Next(26 + 26 + 10);

                if (rand > 35) result += (char)('A' + (rand - 36));
                else if (rand > 9) result += (char)('a' + rand - 10);
                else result += (char)('0' + rand);
            }

            return result;
        }
    }
}
