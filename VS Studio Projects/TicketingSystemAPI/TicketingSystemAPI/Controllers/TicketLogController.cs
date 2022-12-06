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

namespace TicketingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketLogController : Controller
    {
        private readonly IConfiguration _configuration;

        public TicketLogController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // A get method to grab all log entries related to
        //a specific ticket id
        [HttpGet("Get_All_Ticket_Logs")]
        public JsonResult Get_All_Ticket_Logs(int id)
        {
            string query = @"
                    select TicketId, UserId as Commentor, Data from dbo.TicketLogs where TicketId = '" + id + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        //For Creating a New TickeT LOG
        //f calling via API leae the default value fields blank to let the constructor 
        //set those default values.... Otherwise they will be overrriden with whatever they were set to
        [HttpPost("New_Ticket_Log")]
        public JsonResult New_Ticket_Log(TicketLog t)
        {
            string query = @"
                      insert into dbo.TicketLogS (TicketId, UserId, Data, Date) values 
                      ('" +t.TicketId + @"' , 
                        '"+ t.UserId + @"' ,
                        '" + t.Data + @"' ,
                        '" + t.Date + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        // grabs both the ticket itself, and all other logs related to
        //it. Takes a sepcific ticket id
        [HttpGet("Get_Full_Ticket")]
        public JsonResult Get_Full_Ticket(int id)
        {
            string query = @"
                      select TL.TicketId, T.Subject, T.Description, T.Status, T.UpdateDate, TL.UserId as Commentor, TL.Data, TL.Date from dbo.TicketLogs as TL 
                       inner join dbo.Ticket T on TL.TicketId= T.TicketId where TL.TicketId = '" + id + @"' ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        // edited/update a ticketlog entry 
        //You can only change a description after the fact
        //and it has to be the last entry for that specific ticket
        //id... you cannot edit an entry once a log has been put in of a higher
        //TL index than the last
        [HttpPut("Update_TicketLog_Content")]
        public JsonResult Update_TicketLog_Content(int TicketID, int TLID, string data)
        {
            string query = "";

            //account for things left unchanged/null
            //maybe account for a ticket that is open or not?
            if (data != null || data != "")
            {
                query = @"
                    update dbo.TicketLogs set 
                    Data = '" + data
                        + @"' , Date = '" + DateTime.Now + @"'
                    where TicketId = " + TicketID + @" 
                    ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("ConnStr");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader); ;

                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult("Updated Successfully");
            }
            else
            {
                return new JsonResult("Bad Request");
            }
        }


        /*// A get methodfor grabbing all tickets created by a specific
        //user id 
        [HttpGet("Get_All_Tickets_User")]
        public JsonResult Get_All_Tickets_User(int userID, string flag)
        {
            string query = "";
            if (flag == "O")
            {
                //grab open tickets for this user
                query = @"
                    select TicketId, Created_UId as Creator, Subject, Description, Status from dbo.Ticket where Created_UId = '"
                      + userID + @"' and Status = 'Open'";
            }
            else if (flag == "C")
            {
                //grab closed tickets for this user
                query = @"
                    select TicketId, Created_UId as Creator, Subject, Description, Status from dbo.Ticket where Created_UId = '"
                      + userID + @"' and Status= 'Closed'";
            }
            else
            {
                //grabbing all
                query = @"
                    select TicketId, Created_UId as Creator, Subject, Description, Status from dbo.Ticket where Created_UId = '"
                          + userID + @"'";
            }
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        // A get methodfor grabbing all open tickets created by a specific
        //user id 
        //[Route("[HttpGet]/{id}")]
        [HttpGet("Get_All_Open_Tickets")]
        public JsonResult Get_All_Open_Tickets()
        {
            string query = @"
                    select TicketId, Created_UId as Creator, Subject, Description, Status from dbo.Ticket where Status= 'Open'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        // A get methodfor grabbing all open tickets created by a specific
        //user id 
        //[Route("[HttpGet]/{id}")]
        [HttpGet("Get_All_Closed_Tickets")]
        public JsonResult Get_All_Closed_Tickets()
        {
            string query = @"
                    select TicketId, Created_UId as Creator, Subject, Description, Status from dbo.Ticket where Status= 'Closed'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        // A get method being passed a specific ticket id,
        // used for viewing ticket details on click
        [HttpGet("{id}", Name = "Get_Ticket")]
        //[Route("Get_Ticket")]
        public JsonResult Get_Ticket(int id)
        {
            string query = @"
                    select TicketId, Created_UId as Creator, Subject, Category, Description, Status,CreatedDate, UpdateDate  from dbo.Ticket where TicketId = '" + id + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }


        

        // Delete a ticket specified by a ticketid
        [HttpDelete("{id}", Name = "Delete_Ticket")]
        public JsonResult Delete_Ticket(int id)
        {
            string query = @"
                    delete from dbo.Ticket
                    where TicketId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        // close a ticket by setting status to 'Closed'
        [HttpPut("Close_Ticket")]
        public JsonResult Close_Ticket(int id)
        {
            string query = "";
            query = @"
                    update dbo.Ticket set 
                    Status = 'Closed' 
                    where TicketId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Closed Successfully");

        }

        // close a ticket by setting status to 'Open'
        [HttpPut("Open_Ticket")]
        public JsonResult Open_Ticket(int id)
        {
            string query = "";
            query = @"
                    update dbo.Ticket set 
                    Status = 'Open' 
                    where TicketId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Opened Successfully");

        }

        // change a ticket status to intermeddiate 'Pending'
        //In the case of a ticket that has an Entry in TicketLog
        //(so it's been replied to by a tech) and has yet to be closed
        [HttpPut("Mark_Ticket_Seen")]
        public JsonResult Mark_Ticket_Seen(int id)
        {
            string query = "";
            query = @"
                    update dbo.Ticket set 
                    Status = 'Pending' 
                    where TicketId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnStr");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Marked as Pending");

        }*/
    }
}
