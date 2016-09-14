using System;

namespace TestCoursesAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CourseBigDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string CourseID { get; set; }
        //public string Name

        /// <summary>
        /// Example: 20163 -> fall 2016
        /// </summary>
        public string Semester { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}
