using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class CompanyContext: DbContext
    {
        public CompanyContext(): base("CompanyDb")
        {
            //Database.SetInitializer<CompanyContext>(new DropCreateDatabaseAlways<CompanyContext>());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}

