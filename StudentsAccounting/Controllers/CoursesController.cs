using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.Queries;
using StudentsAccounting.Data;
using StudentsAccounting.DTOs;
using StudentsAccounting.Models;

namespace StudentsAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IQuery _query;

        public CoursesController(AppDbContext context, IQuery query)
        {
            _context = context;
            _query = query;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult> GetCourses()
        {
            var result = await _query.GetAllCourses();
            return Ok(result);
        }
    }
}
