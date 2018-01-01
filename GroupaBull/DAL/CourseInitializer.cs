using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GroupaBull.Models;

namespace GroupaBull.DAL
{
    public class CourseInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<CourseContext>
    {
        protected override void Seed(CourseContext context)
        {
            var students = new List<Student>
            {
                new Student{DisplayName="John"},
                new Student{DisplayName="Billy"},
                new Student{DisplayName="Sarah"}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{Title="Chem", SectionNumber=4210, Major="Comp Sci", Subject="COP"},
                new Course{Title="Algo", SectionNumber=4211, Major="Comp Sci", Subject="BAD"},
                new Course{Title="Science", SectionNumber=4212, Major="Comp Sci", Subject="BEE"}
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var groups = new List<Group>
            {
                new Group{},
                new Group{}
            };
            groups.ForEach(s => context.Groups.Add(s));
            context.SaveChanges();

            var majors = new List<Major>
            {
                new Major{Name = "Comp Sci"},
                new Major{Name = "Chem"},
                new Major{Name = "Psychology"}
            };
            majors.ForEach(s => context.Majors.Add(s));
            context.SaveChanges();

        }
    }
}