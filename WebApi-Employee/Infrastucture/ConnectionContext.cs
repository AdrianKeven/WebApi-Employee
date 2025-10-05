using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi_Employee.Domain.Model;

namespace WebApi_Employee.Infrastucture
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5433;" +
                "Database=rh_sample;" +
                "User Id=postgres;" +
                "Password=adrian123;");

        }
    }
}
