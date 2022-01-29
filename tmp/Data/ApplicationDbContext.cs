using System;
using System.Collections.Generic;
using System.Text;
using GiBook.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiBook.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<GiBook> GiBooks { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) :
            base(options)
        {
        }
    }
}
