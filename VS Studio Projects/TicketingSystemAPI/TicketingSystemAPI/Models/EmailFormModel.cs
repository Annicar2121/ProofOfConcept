using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystemAPI.Models
{
    public class EmailFormModel
    {
        public int TicketID { get; set; }
        public string Subject { get; set; }

        [EmailAddress]
        public string UserEmail { get; set; }

        public string Category { get; set; }
        
        public string Content { get; set; }
    }
}
