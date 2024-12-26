using JwtImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtImplementation.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options) { 
                      
        
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }  
    }
}
