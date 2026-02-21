using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TravelBuddy.Models
{
    public class Community
    {
        [Key]
        public int cid { get; set; }
        [NotNull]
        [StringLength(100)]
        public string ?cname { get; set; }
        [NotNull]
        [StringLength(100)]
        public string ?cpassword {get;set;}
        [NotNull]
        public byte[] ?cimage { get; set; }
        [NotNull]
        [StringLength(100)]
        public string ?cemail { get; set; }
    }
    
}