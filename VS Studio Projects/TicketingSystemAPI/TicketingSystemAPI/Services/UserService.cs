using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using TicketingSystemAPI.Authorization;
using TicketingSystemAPI.Entities;
using TicketingSystemAPI.Helpers;
using TicketingSystemAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using System.Security.Claims;
using System;

namespace TicketingSystemAPI.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterModel model);
        void Register_Admin(RegisterModel model);
        void Register_Tech(RegisterModel model);
        IEnumerable<User> Get_Users_By_Role(Role role);
        void Delete_User(int id);
        void ChangePassword(UpdateRequest req);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public void Register(RegisterModel model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("Username '" + model.Email + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            //set role as User
            user.Role = Role.User;

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        //For adding a user to be in the admin role
        public void Register_Admin(RegisterModel model)
        {
            // validate- Do we really want to check this?
            //Or simply use it to make sure the user is already in the system?
            if (_context.Users.Any(x => x.Email == model.Email))
            {
                //This user exists in the DB so we need to UPDATE them?
                //Skipping for now
                throw new AppException("Username '" + model.Email + "' is already taken");
            }
            else
            {
                //User doesn't exist yet, so we are ADDING them
                // map model to new user object
                var user = _mapper.Map<User>(model);

                // hash password
                user.PasswordHash = BCryptNet.HashPassword(model.Password);

                //set role as Admin
                user.Role = Role.Admin;

                // save user
                _context.Users.Add(user);
                _context.SaveChanges();

            }
            
        }

        //For adding a user to be in the admin role
        public void Register_Tech(RegisterModel model)
        {
            // validate- Do we really want to check this?
            //Or simply use it to make sure the user is already in the system?
            if (_context.Users.Any(x => x.Email == model.Email))
            {
                //This user exists in the DB so we need to UPDATE them?
                //Skipping for now
                throw new AppException("Username '" + model.Email + "' is already taken");
            }
            else
            {
                //User doesn't exist yet, so we are ADDING them
                // map model to new user object
                var user = _mapper.Map<User>(model);

                // hash password
                user.PasswordHash = BCryptNet.HashPassword(model.Password);

                //set role as Tech
                user.Role = Role.Tech;

                // save user
                _context.Users.Add(user);
                _context.SaveChanges();

            }

        }

        //For logging in
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new AppException("Email or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }

        //Get All users in the system
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        //Get a user by a specific id
        public User GetById(int id) 
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        //Delete a user with a specific id 
        public void Delete_User(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            //delete them, assums user is not null
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        //Change a user password given an Update Request
        public void ChangePassword(UpdateRequest req)
        {
            //check things
            var user = _context.Users.Find(req.User.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            var passNewHashed = BCryptNet.HashPassword(req.NewPassword);
            var passNewHashed_C = BCryptNet.HashPassword(req.NewPassword_Confirm);
            if (user.PasswordHash == passNewHashed || user.PasswordHash == passNewHashed_C)
            {
                throw new Exception("New Password cannot be the same as old password");
            }
            if(req.NewPassword_Confirm != req.NewPassword_Confirm)
            {
                throw new Exception("Confirm Password does not match New Password");
            }
            //change the password
            // hash password
            user.PasswordHash = BCryptNet.HashPassword(req.NewPassword);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        //returns list of users all assigned to the given role
        public IEnumerable<User> Get_Users_By_Role(Role role)
        {
            IEnumerable<User> users = _context.Users.Where(x => x.Role.Equals(role));
            if (users == null) throw new KeyNotFoundException("There are no users in this role");
            return users;
        }

    }
}