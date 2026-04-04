using System.ComponentModel.DataAnnotations;

namespace TravelBuddy.Models
{
    public class Usr
    {
        
        [Key]
        [StringLength(100)]
        public string ?email { get; set; }
        
        [Required]
        [StringLength(100)]
        public string ?name { get; set; }
        
        [Required]
        public byte[] ?uimage{get;set;}
        
        
        [Required]
        [StringLength(100)]
        public string ?password { get; set; }
        public ICollection<Community> ?communities { get; set; }
        public ICollection<Ride> ?rides { get; set; }
        public ICollection<CommunityChat> ?communityChats { get; set; }
    }
}