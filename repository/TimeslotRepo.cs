using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using Microsoft.EntityFrameworkCore;
using barberdotnet.model.persistence;

namespace barberdotnet.repository
{
    public class TimeslotRepo
    {
        private readonly BarberContext _context;
            public TimeslotRepo(BarberContext context)
            {
                _context = context;
            }
            public async Task<Timeslot> GetById(int id)
            {
                return await _context.timeslots
                .Include(t => t.Day)
                    .ThenInclude(d => d.Month)
                        .ThenInclude(m => m.Year)
                .Include(t => t.Barber)
                .FirstOrDefaultAsync(t => t.Id == id);
            }
        }
}