using System;
using System.Collections.Generic;
using acme_employees.DTO;
using acme_employees.Models;
using AutoMapper;

namespace acme_employees.Profiles
{
    public class SystemUserProfile : Profile
    {
        public SystemUserProfile()
        {
            CreateMap<SystemUser, SystemUserDTO>();
            CreateMap<IEnumerable<SystemUser>, IEnumerable<SystemUserDTO>>();
            CreateMap<SystemUserDTO,SystemUser>();
        }


    }
}
