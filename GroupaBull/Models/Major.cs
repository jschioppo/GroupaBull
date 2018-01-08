using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    //This class is used for list population while the other MajorEntry class is to be stored in the database. This object
    public class Major
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }

        //The string Courses will be a concatenated list of Course Ids which is Course's only Unique value.
        public string Courses { get; set; }

        //CourseList will be built from fetching data using the above Ids
        public List<Course> CourseList { get; set; }
        public string CreatorDisplayName { get; set; }
    }
}