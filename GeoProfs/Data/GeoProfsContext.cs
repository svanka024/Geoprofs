using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Models;

namespace GeoProfs.Data
{
    public class GeoProfsContext : DbContext
    {
        public GeoProfsContext (DbContextOptions<GeoProfsContext> options)
            : base(options)
        {
        }

        public DbSet<GeoProfs.Models.User> Users { get; set; } = default!;
        public DbSet<GeoProfs.Models.Account> Accounts { get; set; } = default!;
        public DbSet<GeoProfs.Models.LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<LeaveRequest>().ToTable("LeaveRequest");
        }
        

        


        
    }
}
