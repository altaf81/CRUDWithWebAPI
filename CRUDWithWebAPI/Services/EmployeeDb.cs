using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDWithWebAPI.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CRUDWithWebAPI.Services
{
    public class EmployeeDb
    {
        string cs = ConfigurationManager.ConnectionStrings["empCs"].ConnectionString;
        public List<Employee> GetAllEmps()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Employee> emps = new List<Employee>();
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("sp_Emp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "selectAll");
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Employee emp = new Employee();
                        emp.Name = dt.Rows[i]["name"].ToString();
                        emp.Salary = Convert.ToInt32(dt.Rows[i]["salary"]);
                        emp.Age = dt.Rows[i]["age"].ToString();
                        emp.Doj = dt.Rows[i]["doj"].ToString();
                        emps.Add(emp);
                    }
                }                
                return emps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }
    }
}