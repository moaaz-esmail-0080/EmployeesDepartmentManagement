using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmplDepartApplication.DTOs;
using EmplDepartCore.Entities;

namespace EmplDepartApplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define entity-to-DTO mappings for Department
            CreateMap<Department, DepartmentDto>(); // Entity to DTO
            CreateMap<DepartmentDto, Department>(); // DTO to Entity

            // Define entity-to-DTO mappings for Employee
            CreateMap<Employee, EmployeeDto>(); // Entity to DTO
            CreateMap<EmployeeDto, Employee>(); // DTO to Entity
        }
    }
}
