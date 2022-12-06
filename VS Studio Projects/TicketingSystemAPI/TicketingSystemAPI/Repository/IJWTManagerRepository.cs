using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystemAPI.Entities;
using TicketingSystemAPI.Models;

namespace TicketingSystemAPI.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
        Boolean checkDBLogin(User u);

        Boolean checkExists(User u);

        Boolean AddUser(User u);

        void Make_Admin(User u);

        void Make_Tech(User u);

        DataTable GetData(string query);

        JsonResult DeleteData(string query);
    }
}
