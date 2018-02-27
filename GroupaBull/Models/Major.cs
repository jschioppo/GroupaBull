using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    //This class is used for list population while the other MajorEntry class is to be stored in the database.
    public class Major
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string CreatorDisplayName { get; set; }

        public List<Course> CourseList { get; set; }

    }
}