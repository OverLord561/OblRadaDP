using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oleg.Models
{
    public class Factory
    {
        public int FactoryId { get; set; }
        public string FactoryName { get; set; }
        public string FactoryAdress { get; set; }
        public string FactoryTelephone { get; set; }
        public string FacctoryBoss { get; set; }
        public string FactoryType { get; set; }

        public List<Job> Job { get; set; }
    }
}