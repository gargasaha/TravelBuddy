using TravelBuddy.Models;
namespace TravelBuddy.Repository
{
    public interface ITravelRepository
    {
        public Task<byte[]> GetImageBytes(IFormFile imageFile);
        public Task<int> registerCommunity(Community community, IFormFile ImageFile);
    }
}