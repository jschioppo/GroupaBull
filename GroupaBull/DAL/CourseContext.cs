using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GroupaBull.Models;

namespace GroupaBull.DAL
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base("CourseContext")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Major> Majors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}