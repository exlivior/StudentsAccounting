using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.Queries;
using StudentsAccounting.Commands;
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
        private readonly ICommand _command;

        public CoursesController(AppDbContext context, IQuery query, ICommand command)
        {
            _context = context;
            _query = query;
            _command = command;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var result = await _query.GetAllCourses();
            return Ok(result);
        }

        // GET: api/Courses/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var result = await _query.GetCourse(id);
            return Ok(result);
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseDTO courseDTO)
        {
            await _command.CreateCourse(courseDTO);
            return CreatedAtAction(nameof(GetCourse), new { id = courseDTO.Id }, courseDTO);
        }

        // DELETE: api/Courses/1
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            _command.DeleteCourse(id);
            return NoContent();
        }
    }
}
