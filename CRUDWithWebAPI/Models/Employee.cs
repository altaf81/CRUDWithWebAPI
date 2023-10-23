using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDWithWebAPI.Models
{
    public class Employee
    {
        public Employee()
        {
            Name = "";
            Salary = 0;
            Age = "";
            Doj = "";
        }

        public string Name { get; set; }
        public int Salary { get; set; }
        public string Age { get; set; }
        public string Doj { get; set; }
    }
}   