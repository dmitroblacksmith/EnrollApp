using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnrollApp.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientRequest> ClientRequests { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<ClientRequestState> ClientRequestStates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            if (!Offers.Any())
            {
                DbInitializer.Seed(this);
            }
        }
    }
}
