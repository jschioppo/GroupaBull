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

            if(unique >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AddStudent(string displayName) {
            StartConnection();
            SqlCommand cmd = new SqlCommand("AddNewStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DisplayName", displayName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddMajor(Major maj)
        {
            StartConnection();
            SqlCommand cmd = new SqlCommand("AddNewMajor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MajorName", maj.MajorName);
            cmd.Parameters.AddWithValue("@Courses", maj.CourseList);
            return true;
        }

        
    }
}