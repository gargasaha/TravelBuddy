using System.ComponentModel.DataAnnotations;

namespace TravelBuddy.Models
{
    public class Usr
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string ?name { get; set; }
        
        [Required]
        public byte[] ?uimage{get;set;}
        
        [Required]
        [EmailAddress]
        public string ?email { get; set; }
        
        [Required]
        [StringLength(100)]
        public string ?password { get; set; }
    }
}