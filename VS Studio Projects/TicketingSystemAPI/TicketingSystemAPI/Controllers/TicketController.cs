using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystemAPI.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using TicketingSystemAPI.Authorization;
using TicketingSystemAPI.Entities;
using TicketingSystemAPI.Services;
using System.Net;
using System.Net.Mail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketingSystemAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITicketsService _ticketsService;

        public TicketController(IConfiguration configuration, ITicketsService ticketsService)
        {
            _configuration = configuration;
            _ticketsService = ticketsService;
        }


        //For sending an email to the techs/admins of the new tickets being created, 
        //or replied to
        [HttpPost("Send_Email")]
        public async Task<ActionResult> Send_Email(EmailFormModel model)
        {
                var body = "<h3><p>Ticket Submitted By: {0}</p></h3> <h4><p><span style='text-decoration: underline;'>Ticket #: " +
                "{4}</span></p></h4> <b><p>Subject: {1}, </b>(Category: {2})</p><p>Content: <br>{3}</br></p><p>< a href = 'http' > Go to Ticket </p> ";
                var message = new MailMessage();
                message.To.Add(new MailAddress("annica@stainlessmotors.com"));  // replace with valid value 
                //message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("annica@stainlessmotors.com");  // replace with valid value
                message.Subject = "New HelpDesk Ticket Generated";
                message.Body = string.Format(body, model.UserEmail, model.Subject, model.Category, model.Content, model.TicketID);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "annica@stainlessmotors.com",  // replace with valid value
                        Password = "RisingMoon2"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "outlook.office365.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
            }

            return Ok("Email sent");
        }




        // A get methodfor grabbing all tickets, open and closed
        [Authorize(Role.Admin, Role.Tech)]
        [HttpGet("Get_All_Tickets")]
        public JsonResult Get_All_Tickets()
        {
            return _ticketsService.Get_All_Tickets();
        }




        // A get methodfor grabbing all tickets by the current user
        //has a flag for open, closed, etc
        [HttpGet("Get_Tickets_Current_User")]
        public JsonResult Get_All_Tickets_User(string flag)
        {
            var currentUser = (User)HttpContext.Items["User"];
            return _ticketsService.Get_All_Tickets_CUser(currentUser, flag);
        }



        // A get methodfor grabbing all tickets created by a specific
        //user id 
        [HttpGet("Get_All_Tickets_User")]
        public JsonResult Get_All_Tickets_User(int userID, string flag)
        {
            return _ticketsService.Get_All_Tickets_ByUser(userID, flag);
        }




        // A get methodfor grabbing all open tickets created by a specific
        //user id 
        [Authorize(Role.Admin, Role.Tech)]
        [HttpGet("Get_All_Open_Tickets")]
        public JsonResult Get_All_Open_Tickets()
        {
            
            return _ticketsService.Get_All_Open_Tickets();
        }




        // A get methodfor grabbing all open tickets created by a specific
        //user id 
        [Authorize(Role.Admin, Role.Tech)]
        [HttpGet("Get_All_Closed_Tickets")]
        public JsonResult Get_All_Closed_Tickets()
        {
            return _ticketsService.Get_All_Closed_Tickets();
        }




        // A get method being passed a specific ticket id,
        // used for viewing ticket details on click
        [Authorize(Role.Admin, Role.Tech)]
        [HttpGet("Get_Ticket")]
        public JsonResult Get_Ticket(int id)
        {

            return _ticketsService.Get_Ticket(id);
        }




        //For Creating a New Ticked
        //f calling via API leae the default value fields blank to let the constructor 
        //set those default values.... Otherwise they will be overrriden with whatever they were set to
        [HttpPost("New_Ticket")]
          public JsonResult New_Ticket(Ticket t)
          {
            var currentUser = (User)HttpContext.Items["User"];
            t.Created_UId = currentUser.Id; 
            JsonResult r= _ticketsService.New_Ticket(t, currentUser);
            if(r != null)
            {
                //assume it went fine and send the email?
                EmailFormModel m = new EmailFormModel();
                m.TicketID = _ticketsService.GetLastTicket(t.Created_UId);
                m.UserEmail = currentUser.Email;
                m.Subject = t.Subject;
                m.Category = "Other";
                m.Content = t.Description;
                Send(m);
            }

            return r;
          }

        //Because it has to be async
        [HttpPost]
        public async void Send(EmailFormModel m)
        {
            await Send_Email(m);
        }





        // edited/update a ticket with a specific id
        //You can only change a description after the fact
        [Authorize(Role.Admin, Role.Tech)]
        [HttpPut( "Update_Ticket_Content")]
        public JsonResult Update_Ticket_Content(int id, string data)
        {
            return _ticketsService.Update_Ticket_Content(id, data);
        }




        // Delete a ticket specified by a ticketid
        [Authorize(Role.Admin, Role.Tech)]
        [HttpDelete( "Delete_Ticket")]
        public JsonResult Delete_Ticket(int id)
        {
            return _ticketsService.Delete_Ticket(id);
        }




        // close a ticket by setting status to 'Closed'
        [Authorize(Role.Admin, Role.Tech)]
        [HttpPut("Close_Ticket")]
        public JsonResult Close_Ticket(int id)
        {

            return _ticketsService.Close_Ticket(id);
            
        }





        // close a ticket by setting status to 'Open'
        [Authorize(Role.Admin, Role.Tech)]
        [HttpPut("Open_Ticket")]
        public JsonResult Open_Ticket(int id)
        {

            return _ticketsService.Open_Ticket(id);

        }





        // change a ticket status to intermeddiate 'Pending'
        //In the case of a ticket that has an Entry in TicketLog
        //(so it's been replied to by a tech) and has yet to be closed
        [Authorize(Role.Admin, Role.Tech)]
        [HttpPut("Mark_Ticket_Seen")]
        public JsonResult Mark_Ticket_Seen(int id)
        {

            return _ticketsService.Mark_Ticket_Seen(id);

        }


    }
}
