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

        public Employee GetOneEmp(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("sp_Emp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "selectOne");
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                Employee emp = new Employee();
                if (dt != null && dt.Rows.Count > 0)
                {
                    emp.Name = dt.Rows[0]["name"].ToString();
                    emp.Salary = Convert.ToInt32(dt.Rows[0]["Salary"]);
                    emp.Age = Convert.ToString(dt.Rows[0]["Age"]);
                    emp.Doj = dt.Rows[0]["doj"].ToString();
                }
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertEmp(Employee emp)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("sp_Emp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@doj", emp.Doj);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows > 0)
                {
                    return "Data inserted";
                }
                return "Data not inserted";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}