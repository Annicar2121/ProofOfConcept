using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystemAPI.Models
{
    public class TicketLog
    {
        [Key]
        public int TLID { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }

        public string Data { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
