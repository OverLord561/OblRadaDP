using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oleg.Models
{
    public class CustomComment
    {
        public int CommentId { get; set; }

        public int LeadershipId { get; set; }

        public string User_Name { get; set; }

        public string User_LabelText { get; set; }

        public string Admin_Answer { get; set; }

        public DateTime Date { get; set; }
    }
}