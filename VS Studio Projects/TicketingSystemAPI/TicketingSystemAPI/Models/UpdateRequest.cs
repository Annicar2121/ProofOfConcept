using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystemAPI.Entities;

namespace TicketingSystemAPI.Models
{
    public class UpdateRequest
    {
        public User User { get; set; }

        public string NewPassword { get; set; }
        public string NewPassword_Confirm { get; set; }
    }
}
