using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    public class GroupEntry
    {
        public int ID;
        public int StudentID;

        public virtual Course CourseInfo { get; set; }
        public virtual Student GroupStudent { get; set; }
    }
}