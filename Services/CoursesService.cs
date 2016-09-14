using System;
using System.Linq;
using System.Collections.Generic;

using TestCoursesAPI.Models;
using TestCoursesAPI.Services.Entities;

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

        public CourseBigDTO GetCourseDetails(int id)
        {
            return (from x in _db.Courses
                    where x.ID == id
                    select new CourseBigDTO
                    {
                       CourseID = x.CourseID,
                        Semester = x.Semester,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate
                    }).SingleOrDefault();
        }

        public List<StudentDTO> GetStudents(int id)
        {
            return (from x in _db.Enrollment
                    join y in _db.Student on x.SID equals y.ID
                    where x.CID == id
                    select new StudentDTO
                    {
                        SSN = y.SSN,
                        Name = y.Name
                    }).ToList();
        }

        public bool UpdateCourse(int id, String newStartDate, String newEndDate)
        {
            var updatedCourse =
                (from x in _db.Courses
                where x.ID == id
                select x).SingleOrDefault();

            if(updatedCourse == null) { return false; }

            updatedCourse.StartDate = newStartDate;
            updatedCourse.EndDate = newEndDate;

            _db.SaveChanges();

            return true;
        }

        public bool DeleteCourse(int id)
        {
            var deleteCourseOrder =
                (from x in _db.Courses
                 where x.ID == id
                 select x).SingleOrDefault();

            if (deleteCourseOrder == null) { return false; }

            var enrollments =
                from x in _db.Enrollment
                where x.CID == id
                select x;

            foreach (var x in enrollments)
            {
                _db.Enrollment.Remove(x);
            }
            _db.SaveChanges();

            _db.Courses.Remove(deleteCourseOrder);
            _db.SaveChanges();

            return true;
        }

        public void AddStudent(int id, StudentDTO item)
        {
            var tempStudent = new StudentObj
            {
                SSN = item.SSN,
                Name = item.Name
            };

            _db.Student.Add(tempStudent);
            _db.SaveChanges();

            var tempEnrollment = new EnrollmentObj
            {

            };
        }

    }
}
