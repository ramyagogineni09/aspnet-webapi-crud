using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //ctor short cut
        {

        }
        //public ApplicationDbContext(DbContextOptions options):base(options)//constructor
        //{

        //}

        public DbSet<Employee> Employees { get; set; } //in database 

    }
}
//this class is for database
