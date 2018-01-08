using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string DisplayName { get; set; }
        public string Courses { get; set; }
        public string Meetups { get; set; }

        public List<Course> CourseList { get; set; }
        public List<Meetup> MeetupList { get; set; }
    }
}