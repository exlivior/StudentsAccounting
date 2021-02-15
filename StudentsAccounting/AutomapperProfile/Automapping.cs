using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StudentsAccounting.Models;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.AutomapperProfile
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<Course, CourseDTO>();
        }
    }
}
