using System;
using System.Collections.Generic;
using acme_employees.DTO;
using acme_employees.Models;
using AutoMapper;

namespace acme_employees.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>();
            CreateMap<EmployeeDTO,Employee>();
        }


    }
}
