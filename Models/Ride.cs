using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBuddy.Models
{
    public class Ride
    {
        [Key]
        public int rideId { get; set; }
        [Required]
        public string ?rideStartLatitude { get; set; }
        [Required]
        public string ?rideStartLongitude { get; set; }
        [Required]
        public string ?rideEndLatitude { get; set; }
        [Required]
        public string ?rideEndLongitude { get; set; }
        [Required]
        public DateTime rideStartTime { get; set; }
        [Required]
        public DateTime rideEndTime { get; set; }
        public string ?rideGroupLeaderEmail { get; set; }
        public int ?communityId { get; set; }
        [ForeignKey("rideGroupLeaderEmail")]
        public Usr ?usr { get; set; }
        [ForeignKey("communityId")]
        public Community ?community { get; set; }
    }
}