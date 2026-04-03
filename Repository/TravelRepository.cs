using Microsoft.Data.SqlClient;
using TravelBuddy.Models;
namespace TravelBuddy.Repository{
    public class TravelRepository{
        private readonly IConfiguration _configuration;
        private SqlDataReader ?rd;
        private SqlConnection ?conn;
        private SqlCommand ?cmd;
        public TravelRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> registerCommunity(Community community, IFormFile ImageFile)
        {
            using (conn = new SqlConnection(_configuration.GetConnectionString("db")))
            {
                try
                {
                    await conn.OpenAsync();
                    using (cmd = new SqlCommand("registerCommunity", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.AddWithValue("@cname", community.cname);
                        cmd.Parameters.AddWithValue("@cpassword", community.cpassword);
                        byte[] imageBytes = ImageFile != null && ImageFile.Length > 0 
                            ? await GetImageBytes(ImageFile) 
                            : Array.Empty<byte>();
                        cmd.Parameters.AddWithValue("@cimage", imageBytes);
                        cmd.Parameters.AddWithValue("@cemail", community.cemail);
                        using (rd = await cmd.ExecuteReaderAsync())
                        {
                            if (rd.Read())
                            {
                                if (rd.FieldCount > 0 && Convert.ToInt32(rd[0]) == -1)
                                {
                                    return -1;
                                }
                            }
                            else if (rd.Read() && Convert.ToInt32(rd[0]) == 1)
                            {
                                return 1;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error registering community: " + ex.Message);
                }
            }
            return 0;
        }

        private async Task<byte[]> GetImageBytes(IFormFile imageFile)
        {
            using var ms = new MemoryStream();
            await imageFile.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}