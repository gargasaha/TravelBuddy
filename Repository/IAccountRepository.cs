using TravelBuddy.Models;
using TravelBuddy.DTOs;
namespace TravelBuddy.Repository
{
    public interface IAccountRepository
    {
        public List<cIdAndCnameDto> getCommunityResult(string email);
        public byte[] getUserProfilePic(string email);
        public string getUserName(string email);
        public bool validateUser(string email, string password);
        public bool saveUser(Usr user);
    }
}
