using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldOne.Models
{
    public class HelloWorldDbContext : IdentityDbContext
    {
        public HelloWorldDbContext()
        {
        }
        public HelloWorldDbContext(DbContextOptions<HelloWorldDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("");
        }
        public DbSet<Employee> Employees { get; set; }

       // public DbSet<User> Users { get; set; }
    }
}
