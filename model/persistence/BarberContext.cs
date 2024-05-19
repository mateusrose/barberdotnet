using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using barberdotnet.model.entities;
using barberdotnet.model.tables;

namespace barberdotnet.model.persistence
{
    public class BarberContext : DbContext
    {
     public BarberContext(DbContextOptions<BarberContext> options) : base(options)
     {
     }
    public DbSet<Year> years { get; set; }
    public DbSet<Month> months { get; set; }
    public DbSet<Day> days { get; set; }
    public DbSet<Barber> barbers { get; set; }
    public DbSet<BarberDay> barberDays { get; set; }
    public DbSet<Timeslot> timeslots { get; set; }

    //Defining not automatically generated relations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BarberDay>()
            .HasKey(bd => new { bd.BarberId, bd.DayId });

        modelBuilder.Entity<BarberDay>()
            .HasOne(bd => bd.Barber)
            .WithMany(b => b.BarberDays)
            .HasForeignKey(bd => bd.BarberId);

        modelBuilder.Entity<BarberDay>()
            .HasOne(bd => bd.Day)
            .WithMany(d => d.BarberDays)
            .HasForeignKey(bd => bd.DayId);
        
    }
    }
}