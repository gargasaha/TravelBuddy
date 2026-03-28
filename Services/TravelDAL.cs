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
        // public async Task registerCommunity(Community community)
        // {
        //     conn=new SqlConnection(_configuration.GetConnectionString("db"));
        //     await conn.OpenAsync();
        //     cmd=new SqlCommand("insert into community values(@cname,@cpassword,@cimage)",conn);
        //     cmd.Parameters.AddWithValue("@cname",community.cname);
        //     cmd.Parameters.AddWithValue("@cpassword",community.cpassword);
        //     cmd.Parameters.AddWithValue("@cimage",community.cimage);
        //     await cmd.ExecuteNonQueryAsync();
        // }
    }
}