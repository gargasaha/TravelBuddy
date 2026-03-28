using TravelBuddy.Models;
using TravelBuddy.Data;
namespace TravelBuddy.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly DBContext db;
        public AccountRepository(DBContext context)
        {
            db = context;
        }    
        public bool saveUser(Usr user)
        {
            try
            {
                int count = db.Usr.Count(x => x.email == user.email);
                if (count > 0) {
                    return false;
                }
                db.Usr.Add(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}