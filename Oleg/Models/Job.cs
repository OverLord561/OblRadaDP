using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oleg.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; }

        public string JobName { get; set; }
        public string JobRequirements { get; set; }
        public string JobDuties { get; set; }
        public string JobConditions { get; set; }
    }
}