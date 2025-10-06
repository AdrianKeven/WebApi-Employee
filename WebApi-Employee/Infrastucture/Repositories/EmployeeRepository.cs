using WebApi_Employee.Domain.DTOs;
using WebApi_Employee.Domain.Model.EmployeeAggregate;

namespace WebApi_Employee.Infrastucture.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(e =>
                new EmployeeDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Photo = e.Photo

                }).ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
