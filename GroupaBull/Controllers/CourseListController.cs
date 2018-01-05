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

        [Authorize]
        public ActionResult ListMajors()
        {
            List<Major> majors = new List<Major>();
            

            return View(majors);


        }

        [HttpPost]
        public void JoinCourse(string course)
        {

            ListMajors();
        }


    }
}