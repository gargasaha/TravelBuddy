using TravelBuddy.Models;
using TravelBuddy.Data;
using TravelBuddy.DTOs;
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
        public byte[] getUserProfilePic(string email)
        {
            byte[] profilePic = null;
            try
            {
                profilePic=db.Usr.Where(x=>x.email==email).Select(x=>x.uimage).FirstOrDefault() ?? null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return profilePic;
        }
        public string getUserName(string email)
        {
            string name = string.Empty;
            try
            {
                name = db.Usr.Where(x=>x.email==email).Select(x=>x.name).FirstOrDefault() ?? string.Empty;    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return name;
        }
        public bool validateUser(string email, string password)
        {
            try
            {
                var numb=db.Usr.Count(x=>x.email==email && x.password==password);
                if (numb == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public List<cIdAndCnameDto> getCommunityResult(string email)
        {
            List<cIdAndCnameDto> communityDtos = new List<cIdAndCnameDto>();
            try
            {
                communityDtos = db.Community.Where(c=>c.cemail==email).Select(c=>new cIdAndCnameDto { cid = c.cid, cname = c.cname, cimage = c.cimage }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return communityDtos;
        }
    }
}