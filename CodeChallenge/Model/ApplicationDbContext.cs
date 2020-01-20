using System;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
    }
}
