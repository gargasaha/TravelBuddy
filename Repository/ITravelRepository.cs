using TravelBuddy.Models;
namespace TravelBuddy.Repository
{
    public interface ITravelRepository
    {
        public bool sendMessage(string message, string ?email, int cid);
        public Task<byte[]> GetImageBytes(IFormFile imageFile);
        public Task<int> registerCommunity(Community community, IFormFile ImageFile);
    }
}