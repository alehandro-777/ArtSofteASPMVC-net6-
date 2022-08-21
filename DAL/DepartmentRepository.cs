using Entities;
using System.Data.SqlClient;
using System.Data;

namespace ArtSofteASPMVC_net6_.DAL
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _constr;

        public DepartmentRepository(IConfiguration configuration)
        {
            _constr = configuration.GetConnectionString("DefaultConnection");
        }
        public List<Department> GetAll()
        {
            List<Department> list = new List<Department>();
            SqlConnection con = new SqlConnection(_constr);
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.DepartmentSelectCommand", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Department result = new Department();
                        result.Id = reader.GetInt32(0);
                        result.Name = reader.GetString(1);
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
    }
    }
