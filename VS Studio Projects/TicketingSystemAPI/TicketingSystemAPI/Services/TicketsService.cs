using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystemAPI.Authorization;
using TicketingSystemAPI.Entities;
using TicketingSystemAPI.Helpers;
using TicketingSystemAPI.Models;

namespace TicketingSystemAPI.Services
{
    public interface ITicketsService
    {

        JsonResult Get_All_Tickets();

        JsonResult Get_All_Tickets_CUser(User user, string flag);
        JsonResult Get_All_Tickets_ByUser(int userID, string flag);
        JsonResult Get_All_Open_Tickets();
        JsonResult Get_All_Closed_Tickets();
        JsonResult Get_Ticket(int id);
        JsonResult New_Ticket(Ticket t, User user);
        JsonResult Update_Ticket_Content(int id, string data);
        JsonResult Delete_Ticket(int id);
        JsonResult Close_Ticket(int id);

        JsonResult Open_Ticket(int id);

        JsonResult Mark_Ticket_Seen(int id);

        int GetLastTicket(int userID);


    }
    public class TicketsService : ITicketsService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public TicketsService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings,
            IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }


        //the logic for opening an sql connection and getting data based on some given query
        public DataTable getData(string query)
        {
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

            return table;
        }

        //get the last made ticket from a specific user id
        public int GetLastTicket(int userID)
        {
            int last = 0;
            string query = @"
                    select Top(1) TicketId from dbo.Ticket where Created_UId = '" + userID + @"'";
            DataTable d = getData(query);
            last = d.Rows[0].Field<int>("TicketId");

            return last;
        }



        // A get methodfor grabbing all tickets, open and closed
        public JsonResult Get_All_Tickets()
        {
            string query = @"
                    select TicketId, Created_UId as Creator, Subject, Description, Status from dbo.Ticket";
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


        // A get methodfor grabbing all tickets by the current user
        //has a flag for open, closed, etc
        [HttpGet("Get_Tickets_Current_User")]
        public JsonResult Get_All_Tickets_CUser(User user, string flag)
        {
            int userID = user.Id;
            string query = "";
            if (flag == "Open")
            {
                //grab open tickets for current
                query = @"
                    select TicketId, Created_UId as Creator, Subject, Description, Status from dbo.Ticket where Created_UId = '"
                      + userID + @"' and Status = 'Open'";
            }
            else if (flag == "Closed")
            {
                //grab closed tickets for current user
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

        // A get methodfor grabbing all tickets created by a specific
        //user id 
        public JsonResult Get_All_Tickets_ByUser(int userID, string flag)
        {
            string query = "";
            if (flag == "Open")
            {
                //grab open tickets for this user
                query = @"
                    select TicketId, Created_UId as Creator, Subject, Description, Status from dbo.Ticket where Created_UId = '"
                      + userID + @"' and Status = 'Open'";
            }
            else if (flag == "Closed")
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


        //For Creating a New Ticked
        //f calling via API leae the default value fields blank to let the constructor 
        //set those default values.... Otherwise they will be overrriden with whatever they were set to
        public JsonResult New_Ticket(Ticket t, User user)
        {
            string query = @"
                      insert into dbo.Ticket (Created_UId, Subject, Description, Status, Category, Assigned_UserId, AssignedDate, ResolvedDate, CreatedDAte, UpdateDate) values 
                      ('" + t.Created_UId + @"' ,
                        '" + t.Subject + @"' ,
                        '" + t.Description + @"' ,
                        '" + t.Status + @"' ,
                        '" + t.Category + @"' ,
                        '" + t.Assigned_UserId + @"' ,
                        '" + t.AssignedDate + @"' ,
                        '" + t.ResolvedDate + @"' ,
                        '" + t.CreatedDate + @"' ,
                        '" + t.UpdateDate + @"')";
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

        // edited/update a ticket with a specific id
        //You can only change a description after the fact
        public JsonResult Update_Ticket_Content(int id, string data)
        {
            string query = "";

            //account for things left unchanged/null
            //maybe account for a ticket that is open or not?
            if (data != null || data != "")
            {
                query = @"
                    update dbo.Ticket set 
                    Description = '" + data
                        + @"' , UpdateDate = '" + DateTime.Now + @"'
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

                return new JsonResult("Updated Successfully");
            }
            else
            {
                return new JsonResult("Bad Request");
            }
        }

        // Delete a ticket specified by a ticketid
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

        }
    }
}
