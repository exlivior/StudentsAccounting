using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentsAccounting.DTOs;
using StudentsAccounting.Models;

namespace StudentsAccounting.AutomapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrerRequest, User>()
                 .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email)); ;
        }
    }
}
