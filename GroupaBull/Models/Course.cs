using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int MajorId { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }
        public string CourseSubject { get; set; }
        public int CRN { get; set; }
        public int SectionNumber { get; set; }
        public string Semester { get; set; }
        public int SchoolYear { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public string AMPM { get; set; }
        public int Members { get; set; }
        public bool Online { get; set; }
        public string CreatorDisplayName { get; set; }
    }
}