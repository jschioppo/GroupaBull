using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupaBull.Models;

namespace GroupaBull.Controllers
{
    public class NewCourseController : Controller
    {
        // GET: NewCourse
        public ActionResult Index()
        {
            CourseDBHandler dbHandler = new CourseDBHandler();
            //Major major1 = new Major();
            //major1.MajorId = 1;
            //major1.MajorName = "Twelve";
            //majors.Add(major1);

            //Major major2 = new Major();
            //major2.MajorId = 2;
            //major2.MajorName = "Thirteen";
            //majors.Add(major2);

            //Major major3 = new Major();
            //major3.MajorId = 3;
            //major3.MajorName = "Fourteen";
            //majors.Add(major3);



            return View(dbHandler.GetAllMajors());
        }
    }
}