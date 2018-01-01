using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string CourseName { get; set; }
        public string StudentDisplayNames { get; set; }
        public string CreatorDisplayname { get; set; }
    }
}