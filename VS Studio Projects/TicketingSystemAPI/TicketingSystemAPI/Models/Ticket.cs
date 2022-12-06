using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystemAPI.Models;

namespace TicketingSystemAPI.Models
{
    public class Ticket
    {
        
        [Key]
        public int TicketId { get; set; }
        public int Created_UId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Subject cannot be longer than 50 characters.")]
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = Models.Status.Open;

        [DisplayFormat(NullDisplayText = "No Category Set")]
        public int Category { get; set; }

        public int Assigned_UserId { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AssignedDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ResolvedDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; } = DateTime.Now;



    }
}
