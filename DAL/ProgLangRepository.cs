using Entities;
using System.Data.SqlClient;
using System.Data;

namespace ArtSofteASPMVC_net6_.DAL
{
    public class ProgLangRepository : IProgLangRepository
    {
        private readonly string _constr;

        public ProgLangRepository(IConfiguration configuration)
        {
            _constr = configuration.GetConnectionString("DefaultConnection");

        }
        public List<Programming_language> GetAll()
        {
            List<Programming_language> list = new List<Programming_language>();
            SqlConnection con = new SqlConnection(_constr);
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.ProgLangSelectCommand", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Programming_language result = new Programming_language();
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
