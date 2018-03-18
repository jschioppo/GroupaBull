using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupaBull.Models;
using System.Diagnostics;
using GroupaBull.Extensions;

namespace GroupaBull.Controllers
{
    public class NewCourseController : Controller
    {
        // GET: NewCourse
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCourse()
        {
            CourseDBHandler dbHandler = new CourseDBHandler();

            //Sends all majors to populate the dropdown
            return View(dbHandler.GetAllMajors());
        }

        [HttpPost]
        public JsonResult VerifyUniqueMajor(string majorName)
        {
            bool flag;
            CourseDBHandler handler = new CourseDBHandler();
            flag = handler.VerifyUniqueMajor(majorName);
            
            return Json(flag);
        }

        [HttpPost]
        public JsonResult AddMajor(string majorName, string title, string subject, int number, int sectNumber, string instructor,
            string semester, int year, string campus, bool newMajor)
        {
            CourseDBHandler handler = new CourseDBHandler();
            int majorId;

            if (newMajor)
            {
                majorId = handler.AddMajor(majorName, User.Identity.GetDisplayname());
            }
            else
            {
                majorId = handler.GetMajorId(majorName);
            }

            Course newCourse = new Course()
            {
                MajorId = majorId,
                Title = title,
                Instructor = instructor,
                CourseSubject = subject,
                SectionNumber = sectNumber,
                SubjectNumber = number,
                Semester = semester,
                SchoolYear = year,
                Members = 0,
                Campus = campus,
                CreatorDisplayName = User.Identity.GetDisplayname()
            };

            if(handler.AddCourse(newCourse, majorName))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}