using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupaBull.Models;
using System.Diagnostics;
using System.Data.SqlClient;

namespace GroupaBull.Controllers
{
    public class CourseListController : Controller
    {
        private SqlConnection con;

        // GET: CourseList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMajors()
        {
            List<Major> majors = new List<Major>();
            Course courseOne = new Course { Title = "Calc 1", Instructor = "Tim Nelson", SectionNumber = 12345, Subject = "COT", CourseNumber = 4210,  };
            Course courseTwo = new Course { Title = "Calc 2", Instructor = "Tim Nelson", SectionNumber = 12345, Subject = "COT", CourseNumber = 4210 };
            Course courseThree = new Course { Title = "Calc 3", Instructor = "Tim Nelson", SectionNumber = 12345, Subject = "COT", CourseNumber = 4210,
                Semester = "Spring", Year = 2017, Day = "T/Th", StartHour = 7, EndHour = 9, StartMinute = 30, EndMinute = 30, AMPM = "PM"};

            List<Course> courseSample = new List<Course>();
            courseSample.Add(courseOne);
            courseSample.Add(courseTwo);
            courseSample.Add(courseThree);
            Major majorOne = new Major { Name = "Comp. Sci", Courses = courseSample };
            Major majorTwo = new Major { Name = "Civil Engineering", Courses = courseSample };

            majors.Add(majorOne);
            majors.Add(majorTwo);

            return View(majors);
        }

        [HttpPost]
        public void JoinCourse(string course)
        {

            ListMajors();
        }


    }
}