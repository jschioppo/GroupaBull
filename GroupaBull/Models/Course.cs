using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }
        public string Subject { get; set; }
        public int CourseNumber { get; set; }
        public int SectionNumber { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public string Day { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public string AMPM { get; set; }
        public int Members { get; set; }
    }
}