using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDWithWebAPI.Services;
using CRUDWithWebAPI.Models;

namespace CRUDWithWebAPI.Controllers
{
    public class EmpController : ApiController
    {
        // GET: api/Emp
        public List<Employee> Get()
        {
            List<Employee> empList = new List<Employee>();
            EmployeeDb eDb = new EmployeeDb();
            empList = eDb.GetAllEmps();
            return empList;
        }

        // GET: api/Emp/5
        public Employee Get(int id)
        {
            EmployeeDb eDb = new EmployeeDb();
            Employee emp = eDb.GetOneEmp(id);
            return emp;
        }

        // POST: api/Emp
        public string Post([FromBody]Employee emp)
        {
            EmployeeDb eDb = new EmployeeDb();
            string result = eDb.InsertEmp(emp);
            return result;
        }

        // PUT: api/Emp/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Emp/5
        public void Delete(int id)
        {
        }
    }
}
