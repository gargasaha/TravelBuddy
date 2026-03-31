using TravelBuddy.Models;
namespace TravelBuddy.Repository
{
    public interface IAccountRepository
    {
        public string getUserName(string email);
        public bool validateUser(string email, string password);
        public bool saveUser(Usr user);
    }
}
