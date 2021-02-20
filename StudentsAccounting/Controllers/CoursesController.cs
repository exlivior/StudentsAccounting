using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.Services;
using StudentsAccounting.Data;
using StudentsAccounting.DTOs;
using StudentsAccounting.Entities;

namespace StudentsAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesServices services;

        public CoursesController(ICoursesServices services)
        {
            this.services = services;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await services.GetAll();
            return Ok(result);
        }

        // GET: api/Courses/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await services.Get(id);
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
            await services.Create(courseDTO);
            return Ok();
        }

        // PUT: api/Courses
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CourseDTO courseDTO)
        {
            await services.Edit(courseDTO);
            return NoContent();
        }

        // DELETE: api/Courses/1
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            services.Delete(id);
            return NoContent();
        }
    }
}
