using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi_Employee.Domain.Model.CompanyAggregate;
using WebApi_Employee.Domain.Model.EmployeeAggregate;

namespace WebApi_Employee.Infrastucture
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5433;" +
                "Database=rh_sample;" +
                "User Id=postgres;" +
                "Password=SUA_SENHA;");

        }
    }
}
