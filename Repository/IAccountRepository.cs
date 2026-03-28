using TravelBuddy.Models;
namespace TravelBuddy.Repository
{
    public interface IAccountRepository
    {
        public bool saveUser(Usr user);
    }
}
