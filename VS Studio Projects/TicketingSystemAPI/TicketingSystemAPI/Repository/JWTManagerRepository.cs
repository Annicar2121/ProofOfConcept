using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketingSystemAPI.Models;
using TicketingSystemAPI.Entities;

namespace TicketingSystemAPI.Repository
{
	public class JWTManagerRepository : IJWTManagerRepository
	{
		Dictionary<string, string> UsersRecords = new Dictionary<string, string>
	{
		{ "user1@example.com","password1"},
		{ "user2","password2"},
		{ "user3","password3"},
	};

		private readonly IConfiguration iconfiguration;
		public JWTManagerRepository(IConfiguration iconfiguration)
		{
			this.iconfiguration = iconfiguration;
		}

		//checks if a user exists in the system with that same email
		public Boolean checkExists(User u)
		{
			string query = @"
                    select UserId, Email, Password, Role from dbo.Users where email = '" + u.Email + @"'";
			DataTable table = new DataTable();
			string sqlDataSource = iconfiguration.GetConnectionString("ConnStr");
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
			if (table == null)
			{
				return false;
			}
			else
			{
				if (table.Rows.Count == 0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		//Checks if the login is valid or no
		public Boolean checkDBLogin (User u)
        {
			string query = @"
                    select UserId, Email, Password, Role from dbo.Users where email = '" + u.Email + @"'";
			DataTable table = new DataTable();
			string sqlDataSource = iconfiguration.GetConnectionString("ConnStr");
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
			if (table == null)
			{
				return false;
            }
            else
            {
				if (table.Rows.Count == 0)
				{
					return false;
				}
				else
				{
					var categoryList = new List<User>(table.Rows.Count);
					foreach (DataRow row in table.Rows)
					{
						var values = row.ItemArray;
						var category = new User()
						{
							Id = (int)values[0],
							Email = (string)values[1],
							Role = (Role)values[2],
							PasswordHash = (string)values[3]
						};
						categoryList.Add(category);
					}

					string email_DB = categoryList[0].Email;
					string password_DB = categoryList[0].Password;

					if (u.Email == email_DB && u.Password == password_DB)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
            }
		}

		//checks if a user exists in the system with that same email
		public Boolean AddUser(User u)
		{
			string query = @"
                    insert into dbo.Users (Email, Password, Role) values ( '" + u.Email + @"' , 
					'" + u.Password + @"' , '"+ u.Role + @"')";
			string sqlDataSource = iconfiguration.GetConnectionString("ConnStr");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();

					myReader.Close();
					myCon.Close();
				}
			}
			//make sure it actually went into the db
            if (checkExists(u))
            {
				return true;
            }
            else
            {
				return false;
            }
		}

		//checks if a user exists in the system with that same email
		public void Make_Admin(User u)
		{
			string query = @" update dbo.Users
                    set Role = 'Admin' where UserId = '" + u.UserId + @"' OR Email = 
					'" + u.Email + @"'";
			string sqlDataSource = iconfiguration.GetConnectionString("ConnStr");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();

					myReader.Close();
					myCon.Close();
				}
			}
			
		}


		//checks if a user exists in the system with that same email
		public void Make_Tech(User u)
		{
			string query = @" update dbo.Users
                    set Role = 'Tech' where UserId = '" + u.UserId + @"' OR Email = 
					'" + u.Email + @"'";
		
			string sqlDataSource = iconfiguration.GetConnectionString("ConnStr");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myReader = myCommand.ExecuteReader();

					myReader.Close();
					myCon.Close();
				}
			}

		}

		//get data given a specific query
		public DataTable GetData(string query)
        {
			
			DataTable table = new DataTable();
			string sqlDataSource = iconfiguration.GetConnectionString("ConnStr");
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

		//delete data given a specific query
		public JsonResult DeleteData(string query)
		{

			DataTable table = new DataTable();
			string sqlDataSource = iconfiguration.GetConnectionString("ConnStr");
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


		//authenticate the user
		public Tokens Authenticate(User users)
		{
			Boolean exists = checkDBLogin(users);
			if (!exists)
			{
				return null;
			}
			else
			{
					// Else we generate JSON Web Token
					var tokenHandler = new JwtSecurityTokenHandler();
					var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
					var tokenDescriptor = new SecurityTokenDescriptor
					{
						Subject = new ClaimsIdentity(new Claim[]
					  {
						new Claim(ClaimTypes.Name, users.Email)
					  }),
						Expires = DateTime.UtcNow.AddMinutes(10),
						SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
					};
					var token = tokenHandler.CreateToken(tokenDescriptor);
					return new Tokens { Token = tokenHandler.WriteToken(token) };
                
			}


		}
	}
}
