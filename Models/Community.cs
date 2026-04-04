using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TravelBuddy.Models
{
    public class Community
    {
        [Key]
        public int cid { get; set; }

        [NotNull]
        [StringLength(100)]
        public string? cname { get; set; }

        [NotNull]
        [StringLength(100)]
        public string? cpassword { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[]? cimage { get; set; }

        [NotNull]
        [StringLength(100)]
        public string? cemail { get; set; }

        [ForeignKey("cemail")]
        public Usr? usr { get; set; }
        public ICollection<Ride> ?rides { get; set; }
        public ICollection<CommunityChat> ?communityChats { get; set; }
    }
    
}