using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<GroupEntry> Groups { get; set; }
    }
}