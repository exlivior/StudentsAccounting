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
        private readonly AppDbContext context;
        private readonly ICourseQuery query;
        private readonly ICourseCommand command;

        public CoursesController(AppDbContext context, ICourseQuery query, ICourseCommand command)
        {
            this.context = context;
            this.query = query;
            this.command = command;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await query.GetAll();
            return Ok(result);
        }

        // GET: api/Courses/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await query.Get(id);
            if (result != null)
            { 
                return Ok(result);
            }
            return NotFound();
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseDTO courseDTO)
        {
            await command.Create(courseDTO);
            return Ok();
        }

        //// PUT: api/Courses
        //[HttpPut]
        //public async Task <ActionResult> Put([FromBody] CourseDTO courseDTO)
        //{
        //    await command.Edit(courseDTO);
        //    return NoContent();
        //}

        // DELETE: api/Courses/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            command.Delete(id);
            return NoContent();
        }
    }
}
