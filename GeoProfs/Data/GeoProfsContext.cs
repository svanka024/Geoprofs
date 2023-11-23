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
        public DbSet<GeoProfs.Models.Status> Statuses { get; set; }
        public DbSet<GeoProfs.Models.Department> Departments { get; set; }
        public DbSet<GeoProfs.Models.Position> Positions { get; set; }
        public DbSet<GeoProfs.Models.Reason> Reasons { get; set; }
        //public DbSet<GeoProfs.Models.Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<LeaveRequest>().ToTable("LeaveRequest");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<Reason>().ToTable("Reason");
            //modelBuilder.Entity<Manager>().ToTable("Manager");
        }
    }
}
