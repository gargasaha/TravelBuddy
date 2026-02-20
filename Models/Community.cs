using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TravelBuddy
{
    public class Community
    {
        [Key]
        public int cid { get; set; }
        [NotNull]
        public string ?cname { get; set; }
        [NotNull]
        public string ?cpassword {get;set;}
        [NotNull]
        public byte[] ?cimage { get; set; }
    }
    
}