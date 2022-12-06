using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketingSystemAPI.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}