using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystemAPI.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; }

    }
}
