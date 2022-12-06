using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystemAPI.Entities;

namespace TicketingSystemAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Entities.User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Role = user.Role;
            Token = token;
        }
    }
}
