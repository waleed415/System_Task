using AutoMapper;
using System_Task.Commands.Employee;
using System_Task.Entities;
using System_Task.Responses.Employee;

namespace System_Task.Mappers
{
    
    public static class EmployeeMapper 
    {
        public static Mapper Mapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EmpolyeeMapperProfile()); 
            });
            return new Mapper(config);
        }
    }

    public class EmpolyeeMapperProfile : Profile
    {
        public EmpolyeeMapperProfile()
        {
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Employee, CreateEmployeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeCommand>().ReverseMap();
        }
    }
}
