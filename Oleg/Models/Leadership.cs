using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oleg.Models
{
    public class Leadership
    {
        public int LeadershipId { get; set; }
        public string LeadershipName { get; set; }
        public string LeadershipPost { get; set; }
        public string LeadershipBiography { get; set; }

        public string LeadershipPhoto { get; set; }
        public string LeadershipDeclaration { get; set; }
    }
}