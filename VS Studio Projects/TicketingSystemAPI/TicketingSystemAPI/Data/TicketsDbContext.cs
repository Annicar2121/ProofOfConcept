using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystemAPI.Models;

namespace TicketingSystemAPI.Data
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketLog> TicketLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(builder);
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<TicketLog>().ToTable("TicketLogs");
        }
    }
}
