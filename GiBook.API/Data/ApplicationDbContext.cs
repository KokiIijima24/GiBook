using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gibook.API.Models;

namespace Gibook.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
      public DbSet<GiBook> GiBiooks { get; set; }
      public DbSet<Book> Books { get; set; }
      public DbSet<Location> Locations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
