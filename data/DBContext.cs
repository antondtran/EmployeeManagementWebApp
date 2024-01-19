using EmployeeApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApplication{
    public class DBContext : DbContext{

         public DbSet<Employee> Employees {get; set;}
        public DBContext(DbContextOptions<DBContext> options) : base(options){}
    }
}