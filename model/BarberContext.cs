using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using barberdotnet.model.entities;

namespace barberdotnet.model
{
    public class BarberContext : DbContext
    {
     public BarberContext(DbContextOptions<BarberContext> options) : base(options)
     {
     }
     public DbSet<Year> years { get; set; }
     public DbSet<Month> months { get; set; }
      public DbSet<Day> days { get; set; }
    }
   
}