using AutoMapper;
using Employee.DTOs;
using Employee.Models;

namespace Employee.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeSalary, EmployeeSalaryDto>().ReverseMap();
        }
    }
}
