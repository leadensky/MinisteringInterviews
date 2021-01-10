using Microsoft.EntityFrameworkCore;
using MinisteringInterviews.Domain;
using System;

namespace MinisteringInterviews.Data
{
    public class MIContext : DbContext
    {
        public MIContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Companionship> Companionships { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}
