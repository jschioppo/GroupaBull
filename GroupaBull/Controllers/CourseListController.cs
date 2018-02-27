﻿using System;
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
            CourseDBHandler handler = new CourseDBHandler();

            majors = handler.GetAllMajors();
            
            return View(majors);
        }

        [HttpPost]
        public ActionResult GetCourse(int courseId)
        {
            CourseDBHandler handler = new CourseDBHandler();
            Course targetCourse = handler.GetCourse(courseId);
            Debug.WriteLine(targetCourse.CourseId);
            Debug.WriteLine(targetCourse.Title);
            return RedirectToAction("ViewCourse", targetCourse);
        }

        public ActionResult ViewCourse(int courseId)
        {
            CourseDBHandler handler = new CourseDBHandler();
            Course targetCourse = handler.GetCourse(courseId);
            Debug.WriteLine(targetCourse.CourseId);
            Debug.WriteLine(targetCourse.Title);
            return View(targetCourse);
        }

        [HttpPost]
        public void JoinCourse(int courseId)
        {

            ListMajors();
        }


    }
}