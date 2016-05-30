using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Oleg.Models
{
    public class OblRadaContext : DbContext
    {
        public OblRadaContext() : base("OblRadaContext") { }

        public DbSet<Novelty> News { get; set; }

        public DbSet<Outlay> Outlaies { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Factory>Factories { get; set; }

        public DbSet<Leadership> Leaderships { get; set; }

        public DbSet<UserComment> UserComments { get;set;}

    }
}