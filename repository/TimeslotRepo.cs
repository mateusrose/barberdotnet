using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using Microsoft.EntityFrameworkCore;
using barberdotnet.model.persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace barberdotnet.repository
{
    public class TimeslotRepo
    {
        private readonly BarberContext _context;
        private readonly DayRepo _dayRepo;
        public TimeslotRepo(BarberContext context, DayRepo dayRepo)
        {
            _context = context;
            _dayRepo = dayRepo;
        }
        public async Task<Timeslot> GetById(int id)
        {
            var timeslot = await _context.timeslots
            .Include(t => t.Day)
                .ThenInclude(d => d.Month)
                    .ThenInclude(m => m.Year)
            .Include(t => t.Barber)
            .FirstOrDefaultAsync(t => t.Id == id);

            return timeslot;
        }
        public async Task<Timeslot> GetByExactTime(int year, int month, int day, int time, int barber)
        {
            var timeslot = await _context.timeslots
            .Include(t => t.Day)
                .ThenInclude(d => d.Month)
                    .ThenInclude(m => m.Year)
            .Include(t => t.Barber)
            .FirstOrDefaultAsync(t => t.Day.Month.Year.YearNumber == year &&
                                    t.Day.Month.MonthNumber == month &&
                                    t.Day.MonthDay == day &&
                                    t.Barber.Id == barber &&
                                    t.Time == time);

            return timeslot;
        }
        public async Task<List<Timeslot>> GetTimeslotsByDayBarber(int year, int month, int day, int barber)
        {
            var dayObj = await _dayRepo.GetByExactDay(year, month, day);

            var timeslots = await _context.timeslots
            .Include(t => t.Day)
                .ThenInclude(d => d.Month)
                    .ThenInclude(m => m.Year)
            .Include(t => t.Barber)
            .Where(t => t.Day.Id == dayObj.Id)
            .Where(t => t.Barber.Id == barber)
            .ToListAsync();

            return timeslots;
        }
    }
}