using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model
{
    public class DataBaseInit
    {
        private readonly BarberContext _context;

        public DataBaseInit(BarberContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var year = new Year { };
            var year2 = new Year { };
            var year3 = new Year { };

            _context.years.Add(year);
            _context.years.Add(year2);
            _context.years.Add(year3);
            _context.SaveChanges();
        }
        
    }
}