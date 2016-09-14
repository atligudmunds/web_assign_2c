using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TestCoursesAPI.Models;
using TestCoursesAPI.Services;

namespace TestCoursesAPI.API.Controllers
{
    [Route("api/courses")]
    public class CoursesController : Controller
    {
        private readonly ICoursesService _service;

        public CoursesController(ICoursesService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<CourseLiteDTO> GetCoursesOnSemester(string semester = null)
        {
            if(semester == null)
            {
                semester = "20163";
            }

            return _service.GetCourseBySemester(semester);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailsOfCourse(int id)
        {
            CourseBigDTO temp = _service.GetCourseDetails(id);
            if(temp == null)
            {
                return NotFound();
            }
            return new ObjectResult(temp);
            //return _service.GetCourseDetails(id);
        }

        [HttpGet("{id}/students")]
        public List<StudentDTO> GetStudentsByCourse(int id)
        {
            //StudentDTO temp = _service.GetStudents(id);
            return _service.GetStudents(id);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] EditCourseViewModel item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            bool result = _service.UpdateCourse(id, item.StartDate, item.EndDate);
            if(result == false)
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourseById(int id)
        {
            bool result = _service.DeleteCourse(id);
            if(result == false)
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpPost("{id/students}")]
        public IActionResult AddStudentToCourse(int id, [FromBody] StudentDTO item)
        {
            _service.AddStudent(id, item);
            return new NoContentResult();
        }

    }
}