using System;

namespace TestCoursesAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CourseLiteDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string CourseID { get; set; }


        /// <summary>
        /// Example: 20163 -> fall 2016
        /// </summary>
        public string Semester { get; set; }


    }
}
