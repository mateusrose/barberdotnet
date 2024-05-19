using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using barberdotnet.model.persistence;

namespace barberdotnet.repository
{
    public class BarberRepo
    {
        private readonly BarberContext _context;
        public BarberRepo(BarberContext context)
        {
            _context = context;
        }
        //GET List of All Barbers
        public Task<List<Barber>> GetBarbers()
        {
            return Task.FromResult(_context.barbers.ToList());
        }
    }
}