using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBuddy.Models
{
    public class ChatFile
    {
        [Key]
        public int chatid { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[] ?fileData { get; set; }
    }
}