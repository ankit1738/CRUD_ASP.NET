using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class EmployeeDetails
    {
        public Employee Employee { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public Project Project { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public int[] employeeIds { get; set; }
    }
}