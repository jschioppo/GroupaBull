using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using GroupaBull.Extensions;
using Microsoft.AspNet.Identity;
using System.Diagnostics;

namespace GroupaBull.Models
{
    public class CourseDBHandler
    {
        private SqlConnection con;

        private void StartConnection()
        {
            string ConString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(ConString);
        }

        public bool VerifyUniqueStudent(string displayName)
        {
            StartConnection();
            SqlCommand cmd = new SqlCommand("VerifyUniqueStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DisplayName", displayName);

            con.Open();
            var unique = (int)cmd.ExecuteScalar();
            con.Close();

            return (unique >= 1 ? false : true);
        }

        public bool VerifyUniqueMajor(string majorName)
        {
            StartConnection();
            SqlCommand cmd = new SqlCommand("VerifyUniqueMajor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MajorName", majorName);

            con.Open();
            var unique = (int)cmd.ExecuteScalar();
            con.Close();

            return (unique >= 1 ? false : true);
        }

        public bool AddStudent(string displayName) {
            StartConnection();
            SqlCommand cmd = new SqlCommand("AddNewStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DisplayName", displayName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return (i >= 1 ? true : false);
        }

        public int AddMajor(string majorName, string displayName)
        {
            StartConnection();
            SqlCommand cmd = new SqlCommand("AddNewMajor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MajorName", majorName);
            cmd.Parameters.AddWithValue("@CreatorDisplayName", displayName);

            con.Open();
            int id = (int)cmd.ExecuteScalar();
            con.Close();

            return id;
        }

        public bool AddCourse(Course course, string majorName)
        {
            int majorId = GetMajorId(majorName);

            StartConnection();
            SqlCommand cmd = new SqlCommand("AddNewCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MajorId", majorId);
            cmd.Parameters.AddWithValue("@Title", course.Title);
            cmd.Parameters.AddWithValue("@Instructor", course.Instructor);
            cmd.Parameters.AddWithValue("@CourseSubject", course.CourseSubject);
            cmd.Parameters.AddWithValue("@SubjectNumber", course.SubjectNumber);
            cmd.Parameters.AddWithValue("@SectionNumber", course.SectionNumber);
            cmd.Parameters.AddWithValue("@Semester", course.Semester);
            cmd.Parameters.AddWithValue("@SchoolYear", course.SchoolYear);
            cmd.Parameters.AddWithValue("@Members", 0);
            cmd.Parameters.AddWithValue("@Campus", course.Campus);
            cmd.Parameters.AddWithValue("@CreatorDisplayName", course.CreatorDisplayName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return (i >= 1 ? true: false);
        }

        public int GetMajorId(string majorName)
        {
            StartConnection();
            SqlCommand cmd = new SqlCommand("GetMajorId", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MajorName", majorName);

            con.Open();
            int majorId = (int)cmd.ExecuteScalar();
            con.Close();

            return majorId;
        }

        public List<Major> GetAllMajors()
        {
            StartConnection();
            List<Major> majors = new List<Major>();

            SqlCommand cmd = new SqlCommand("GetAllMajors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                majors.Add(
                    new Major
                    {
                        MajorId = Convert.ToInt32(dr["MajorId"]),
                        MajorName = Convert.ToString(dr["MajorName"]),
                        CourseList = GetMajorCourses(Convert.ToInt32(dr["MajorId"]))
                    });
            }

            return majors;
        }

        public List<Course> GetMajorCourses(int majorId)
        {
            StartConnection();
            List<Course> courses = new List<Course>();

            SqlCommand cmd = new SqlCommand("GetMajorCourses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue("@MajorId", majorId);

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                courses.Add(
                    new Course
                    {
                        CourseId = Convert.ToInt32(dr["CourseId"]),
                        MajorId = Convert.ToInt32(dr["MajorId"]),
                        Title = Convert.ToString(dr["Title"]),
                        Instructor = Convert.ToString(dr["Instructor"]),
                        CourseSubject = Convert.ToString(dr["CourseSubject"]),
                        SubjectNumber = Convert.ToInt32(dr["SubjectNumber"]),
                        SectionNumber = Convert.ToInt32(dr["SectionNumber"]),
                        Semester = Convert.ToString(dr["Semester"]),
                        SchoolYear = Convert.ToInt32(dr["SchoolYear"]),
                        Members = Convert.ToInt32(dr["Members"]),
                        CreatorDisplayName = Convert.ToString(dr["CreatorDisplayName"])
                    });
            }


            return courses;
        }

        public Course GetCourse(int courseId)
        {
            StartConnection();
            Course target = new Course();

            SqlCommand cmd = new SqlCommand("GetCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CourseId", courseId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                target.CourseId = Convert.ToInt32(dr["CourseId"]);
                target.MajorId = Convert.ToInt32(dr["MajorId"]);
                target.Title = Convert.ToString(dr["Title"]);
                target.Instructor = Convert.ToString(dr["Instructor"]);
                target.CourseSubject = Convert.ToString(dr["CourseSubject"]);
                target.SectionNumber = Convert.ToInt32(dr["SectionNumber"]);
                target.SubjectNumber = Convert.ToInt32(dr["SubjectNumber"]);
                target.Semester = Convert.ToString(dr["Semester"]);
                target.SchoolYear = Convert.ToInt32(dr["SchoolYear"]);
                target.Members = Convert.ToInt32(dr["Members"]);
                target.CreatorDisplayName = Convert.ToString(dr["CreatorDisplayName"]);
            }
            return target;
        }

        public int GetStudentId()
        {
            StartConnection();
            string displayName = HttpContext.Current.User.Identity.GetDisplayname();

            SqlCommand cmd = new SqlCommand("GetStudentId", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DisplayName", displayName);

            con.Open();
            int studentId = (int)cmd.ExecuteScalar();
            con.Close();

            return studentId;
        }

        public bool AddEnrollment(int courseId)
        {
            int studentId = GetStudentId();
            if(CheckUniqueEnrollment(courseId) == false)
            {
                Debug.WriteLine("Test");
                return false;
            }
            StartConnection();

            SqlCommand cmd = new SqlCommand("AddNewEnrollment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentId", studentId);
            cmd.Parameters.AddWithValue("@CourseId", courseId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return (i >= 1 ? true : false);
        }

        public bool CheckUniqueEnrollment(int courseId)
        {
            int studentId = GetStudentId();
            StartConnection();

            SqlCommand cmd = new SqlCommand("VerifyUniqueEnrollment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentId", studentId);
            cmd.Parameters.AddWithValue("@CourseId", courseId);

            con.Open();
            var unique = (int)cmd.ExecuteScalar();
            con.Close();

            return (unique >= 1 ? false : true);
        }

        
    }
}