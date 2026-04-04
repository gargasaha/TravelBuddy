using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBuddy.Models
{
    public class CommunityChat
    {
        [Key]
        public int communityChatId {get; set;}
        [Required]
        [ForeignKey("cid")]
        public int cid {get; set;}
        public Community ?community {get; set;}
        [Required]
        [ForeignKey("email")]
        public string ?email {get; set;}
        public Usr ?usr {get; set;}
        [Required]
        [StringLength(500)]
        public string ?message {get; set;}
    }
}