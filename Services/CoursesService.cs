using System;
using System.Linq;
using System.Collections.Generic;

using TestCoursesAPI.Models;

namespace TestCoursesAPI.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDataContext _db;
        public CoursesService(AppDataContext db)
        {
            _db = db;
        }

        public List<CourseLiteDTO> GetCourseBySemester(string semester)
        {
            return (from x in _db.Courses
                    where x.Semester == semester
                    select new CourseLiteDTO
                    {
                        CourseID = x.CourseID,
                        Semester = x.Semester
                    }).ToList();
        }
        // TODO: add more functions!
    }
}
