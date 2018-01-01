using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupaBull.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;

namespace GroupaBull.Controllers
{
    public class CourseListController : Controller
    {
        

        // GET: CourseList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMajors()
        {
            List<Major> majors = new List<Major>();
            Course courseOne = new Course
            {
                Title = "Calc 1",
                Instructor = "Tim Nelson",
                SectionNumber = 12345,
                CourseSubject = "COT",
                CRN = 4210
            };
            Course courseTwo = new Course
            {
                Title = "Calc 2",
                Instructor = "Tim Nelson",
                SectionNumber = 12345,
                CourseSubject = "COT",
                CRN = 4210 };
            Course courseThree = new Course
            {
                Title = "Calc 3",
                Instructor = "Tim Nelson",
                SectionNumber = 12345,
                CourseSubject = "COT",
                CRN = 4210,
                Semester = "Spring",
                SchoolYear = 2017,
                Day = "T/Th",
                StartTime = new TimeSpan(10, 30, 0),
                EndTime = new TimeSpan(12, 30, 0)
            };

            List<Course> courseSample = new List<Course>();
            courseSample.Add(courseOne);
            courseSample.Add(courseTwo);
            courseSample.Add(courseThree);

            Major tMajor = new Major
            {
                MajorName = "Comp Sci",
                CourseList = courseSample
            };
            majors.Add(tMajor);

            return View(majors);


        }

        [HttpPost]
        public void JoinCourse(string course)
        {

            ListMajors();
        }


    }
}