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
    }
}