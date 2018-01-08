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
        //Add Major
        //Get Majors
        //Add Class to Major - Requires Major
        //Get courses within a major
        //Get meetups within a course
        //Add meetups

        private void StartConnection()
        {
            string ConString = ConfigurationManager.ConnectionStrings["GroupaBullDb"].ToString();
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
            cmd.Parameters.AddWithValue("@Courses", "");
            cmd.Parameters.AddWithValue("@CreatorDisplayName", displayName);

            con.Open();
            int id = (int)cmd.ExecuteScalar();
            con.Close();

            return id;
        }

        public int AddCourse(Course course, string majorName)
        {
            StartConnection();
            SqlCommand cmd = new SqlCommand("AddNewCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            int majorId = GetMajorId(majorName);

            cmd.Parameters.AddWithValue("@MajorId", majorId);
            

            return 1;
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
                        MajorName = Convert.ToString(dr["MajorName"])
                    });
            }

            return majors;

        }

        
    }
}