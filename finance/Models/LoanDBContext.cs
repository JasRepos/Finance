using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class LoanDBContext : DbContext
    {
        public DbSet<customer> customers { get; set; }
        public DbSet<loans> loans { get; set; }

    }
}