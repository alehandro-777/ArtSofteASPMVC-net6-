using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;

namespace ArtSofteASPMVC_net6_.DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _constr;

        public EmployeeRepository(IConfiguration configuration, IWebHostEnvironment env)
        {
            _constr = configuration.GetConnectionString("LocalConnection");
            
            //for local mdf
            if (_constr.Contains("%CONTENTROOTPATH%"))
            {
                _constr = _constr.Replace("%CONTENTROOTPATH%", env.ContentRootPath);
            }
        }
        //l.Id, l.Name, l.SurName, l.Age, l.dName, p.Name
        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            SqlConnection con = new SqlConnection(_constr);
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.EmployeeSelectCommand", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee result = new Employee();
                        result.Id = reader.GetInt32(0);
                        result.Name = reader.GetString(1);
                        result.SurName = reader.GetString(2);
                        result.Age = reader.GetInt32(3);
                        result.Department = reader.GetString(4);
                        result.ProgrammingLang = reader.GetString(5);
                        list.Add(result);
                    }
                }
                reader.Close();
                return list;
            }
            catch
            {
                return list;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        //Id, Name, SurName, DepartmentId, ProgrammingLangId, Age, Gender
        public Employee InsertData(Employee objemp)
        {
            Employee result = new Employee();
            SqlConnection con = new SqlConnection(_constr);
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.EmployeeInsertCommand", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@Id", 0);    
                cmd.Parameters.AddWithValue("@Name", objemp.Name);
                cmd.Parameters.AddWithValue("@SurName", objemp.SurName);
                cmd.Parameters.AddWithValue("@Age", objemp.Age);
                cmd.Parameters.AddWithValue("@DepartmentId", objemp.DepartmentId);
                cmd.Parameters.AddWithValue("@ProgrammingLangId", objemp.ProgrammingLangId);
                cmd.Parameters.AddWithValue("@Gender", objemp.Gender);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Id = reader.GetInt32(0);
                        result.Name = reader.GetString(1);
                        result.SurName = reader.GetString(2);
                        result.DepartmentId = reader.GetInt32(3);
                        result.ProgrammingLangId = reader.GetInt32(4);
                        result.Age = reader.GetInt32(5);
                        result.Gender = reader.GetString(6);
                    }
                }
                reader.Close();
                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }
        //Id, Name, SurName, DepartmentId, ProgrammingLangId, Age, Gender
        public Employee UpdateData(Employee objemp)
        {
            Employee result = new Employee();
            SqlConnection con = new SqlConnection(_constr);
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.EmployeeUpdateCommand", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", objemp.Id);
                cmd.Parameters.AddWithValue("@Name", objemp.Name);
                cmd.Parameters.AddWithValue("@SurName", objemp.SurName);
                cmd.Parameters.AddWithValue("@Age", objemp.Age);
                cmd.Parameters.AddWithValue("@DepartmentId", objemp.DepartmentId);
                cmd.Parameters.AddWithValue("@ProgrammingLangId", objemp.ProgrammingLangId);
                cmd.Parameters.AddWithValue("@Gender", objemp.Gender);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Id = reader.GetInt32(0);
                        result.Name = reader.GetString(1);
                        result.SurName = reader.GetString(2);
                        result.DepartmentId = reader.GetInt32(3);
                        result.ProgrammingLangId = reader.GetInt32(4);
                        result.Age = reader.GetInt32(5);
                        result.Gender = reader.GetString(6);
                    }
                }
                reader.Close();
                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        public int Delete(int id)
        {
            SqlConnection con = new SqlConnection(_constr);
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.EmployeeDeleteCommand", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        //Id, Name, SurName, DepartmentId, ProgrammingLangId, Age, Gender
        public Employee GetByID(int id)
        {
            Employee result = new Employee();
            SqlConnection con = new SqlConnection(_constr);
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.EmployeeSelectById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Id = reader.GetInt32(0);
                        result.Name = reader.GetString(1);
                        result.SurName = reader.GetString(2);
                        result.DepartmentId = reader.GetInt32(3);
                        result.ProgrammingLangId = reader.GetInt32(4);
                        result.Age = reader.GetInt32(5);
                        result.Gender = reader.GetString(6);
                    }
                }
                reader.Close();
                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }
    }
}
