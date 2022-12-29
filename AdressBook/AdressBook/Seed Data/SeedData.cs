using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdressBook.Data;
using System;
using System.Linq;
using AdressBook.Models;
using System.Net;

namespace AdressBook.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AdressBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AdressBookContext>>()))
            {
                // Look for any movies.
                if (context.Workplace.Any())
                {
                    return;   // DB has been seeded
                }

                context.Workplace.AddRange(
                    new Workplace
                    {
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}