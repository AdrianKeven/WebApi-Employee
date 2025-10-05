using AutoMapper;

namespace WebApi_Employee.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Domain.Model.Employee, Domain.DTOs.EmployeeDTO>();
        }
    }
}
