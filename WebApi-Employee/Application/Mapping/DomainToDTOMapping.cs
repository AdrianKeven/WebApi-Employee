using AutoMapper;
using WebApi_Employee.Domain.Model.EmployeeAggregate;

namespace WebApi_Employee.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Employee, Domain.DTOs.EmployeeDTO>();
        }
    }
}
