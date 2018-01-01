using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupaBull.Models
{
    public class Meetup
    {
        public int MeetupId { get; set; }
        public int CourseId { get; set; }
        public string Location { get; set; }
        public DateTime MeetupTime { get; set; }
        public int Members { get; set; }
        public string Purpose { get; set; }
        public string Extra { get; set; }
        public string CreatorDisplayName { get; set; }
    }
}