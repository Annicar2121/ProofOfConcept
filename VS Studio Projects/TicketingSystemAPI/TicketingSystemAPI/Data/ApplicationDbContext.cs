
using Microsoft.EntityFrameworkCore;
using TicketingSystemAPI.Models;

namespace TicketingSystemAPI.Data

{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(builder);
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
