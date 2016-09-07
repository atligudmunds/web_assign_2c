using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestCoursesAPI.Models;

namespace TestCoursesAPI.Services
{
    public interface ICoursesService
    {
        List<CourseLiteDTO> GetCourseBySemester(string semester);
    }
}
