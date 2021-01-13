using Microsoft.EntityFrameworkCore;
using MinisteringInterviews.Domain;
using System;

namespace MinisteringInterviews.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            ContextOptions = options;
        }

        public DbSet<Member> Members { get; set; }
        //public DbSet<Companionship> Companionships { get; set; }
        //public DbSet<Appointment> Appointments { get; set; }

        protected DbContextOptions<AppDbContext> ContextOptions { get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Member>(m =>
            {
                m.HasKey(x => x.Id);
                m.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
                m.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            });
        }

    }
}
