using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicketingSystemAPI.Entities;

namespace TicketingSystemAPI.Helpers
{
    public class DataContext : DbContext
    {

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("ConnStr"));
        }

        public DbSet<User> Users { get; set; }
    }
}