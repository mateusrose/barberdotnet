using barberdotnet.model;
using barberdotnet.model.DTOs;
using barberdotnet.model.entities;
using barberdotnet.model.persistence;
using Microsoft.EntityFrameworkCore;

namespace barberdotnet.repository;

public class WeekRepo
{
    private readonly BarberContext _context;

    public WeekRepo(BarberContext context)
    {
        _context = context;
    }
    
    public async Task<List<Day>> GetAllFromWeekBarber(int year, int month, int week, int barber)
    {
        
        var days = await _context.days
            .Include(d => d.Month)
                .ThenInclude(m => m.Year)
            .Include(d => d.Timeslots)
                .ThenInclude(t=>t.Barber)
            .Where(d => d.Month.Year.YearNumber == year &&
                        d.Month.MonthNumber == month
                        && d.WeekNumber == week
                        )
            .ToListAsync();

        return days;

    }
}