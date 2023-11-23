using GeoProfsNew.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeoProfsNew.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        //public DbSet<GeoProfs.Models.Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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