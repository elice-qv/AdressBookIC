using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdressBook.Models;

namespace AdressBook.Data
{
    public class AdressBookContext : DbContext
    {
        public AdressBookContext (DbContextOptions<AdressBookContext> options)
            : base(options)
        {
        }

        public DbSet<AdressBook.Models.Workplace> Workplace { get; set; } = default!;
    }
}
