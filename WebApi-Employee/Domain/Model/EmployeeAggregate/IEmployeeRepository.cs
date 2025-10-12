using WebApi_Employee.Domain.DTOs;

namespace WebApi_Employee.Domain.Model.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
        void Remove(int id);
        void Update(Employee employee);
    }
}
