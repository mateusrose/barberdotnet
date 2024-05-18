using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using barberdotnet.model.persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace barberdotnet.repository
{
    public class DayRepo
    {
        public readonly BarberContext _context;
        public DayRepo(BarberContext context)
        {
            _context = context;
        }
        public async Task<Day> GetById(int id)
        {
            var day = await _context.days
            .Include(d => d.Month)
                .ThenInclude(m => m.Year)
            .Include(d => d.Timeslots)
            .FirstOrDefaultAsync(d => d.Id == id);

            return day;
        }

    }
}