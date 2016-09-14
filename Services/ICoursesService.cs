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

        CourseBigDTO GetCourseDetails(int id);

        bool UpdateCourse(int id, String newStartDate, String newEndDate);

        bool DeleteCourse(int id);

        List<StudentDTO> GetStudents(int id);

        void AddStudent(int id, StudentDTO item);
    }
}
