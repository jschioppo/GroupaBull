using System;
using System.ComponentModel.DataAnnotations;
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
        public int SubjectNumber { get; set; }
        public int SectionNumber { get; set; }
        public string Semester { get; set; }
        public int SchoolYear { get; set; }
        public int Members { get; set; }
        public string Campus { get; set; }
        public string CreatorDisplayName { get; set; }
    }
}