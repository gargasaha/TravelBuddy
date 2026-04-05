using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBuddy.Models
{
    public class CommunityChat
    {
        [Key]
        public int communityChatId {get; set;}
        [Required]
        public int communityId {get; set;}
        public Community ?community {get; set;}
        [Required]
        public string ?usrEmail {get; set;}
        public Usr ?usr {get; set;}
        [Required]
        [StringLength(500)]
        public string ?message {get; set;}
        [Required]
        public DateTime timestamp {get; set;}
    }
}