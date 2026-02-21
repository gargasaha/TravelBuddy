using Microsoft.Data.SqlClient;
using TravelBuddy.Models;
namespace TravelBuddy{
    public class TravelDAL{
        private readonly IConfiguration _configuration;
        private SqlDataReader ?rd;
        private SqlConnection ?conn;
        private SqlCommand ?cmd;
        public TravelDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> registerCommunity(Community community,IFormFile ImageFile)
        {
            conn=new SqlConnection(_configuration.GetConnectionString("db"));
            try{
                await conn.OpenAsync();
                cmd=new SqlCommand("registerCommunity",conn);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cname",community.cname);
                cmd.Parameters.AddWithValue("@cpassword",community.cpassword);
                byte[] imageBytes = new byte[0];
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await ImageFile.CopyToAsync(ms);
                    imageBytes = ms.ToArray();
                }
                cmd.Parameters.AddWithValue("@cimage",imageBytes);
                cmd.Parameters.AddWithValue("@cemail",community.cemail);
                rd=await cmd.ExecuteReaderAsync();
                if (rd.Read())
                {
                    if(rd.FieldCount > 0 && Convert.ToInt32(rd[0]) == -1)
                    {
                        return -1;
                    }
                    
                }
                else if (rd.Read() && Convert.ToInt32(rd[0]) == 1)
                {
                    return 1;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error registering community: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }
    }
}