using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using barberdotnet.model.tables;

namespace barberdotnet.model.persistence
{
    public class DataBaseInit
    {
        private readonly BarberContext _context;
        private List<Barber> Barbers = [];

        public DataBaseInit(BarberContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
           // DBInit();
            //AddBarbers(2);
            //AddYears(1);
            // dotnet ef migrations add InitialCreate --context AuthContext
            // dotnet ef database update --context AuthContext

            _context.SaveChanges();
        }
        private void DBInit()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
        private void AddBarbers(int i)
        {
            for (int j = 0; j < i; j++)
            {
                var barber = new Barber { Name = "Barber" + ((int)j+1) };
                Barbers.Add(barber);
                _context.barbers.Add(barber);
            }
        }

        private void AddYears(int years)
        {
            for (int i = 0; i < years; i++)
            {
                var year = new Year();
                AddMonths(year);
                _context.years.Add(year);
            }
        }
        private void AddMonths(Year year)
        {
            for (int i = 1; i <= 12; i++)
            {
                var month = new Month { MonthNumber = i, Year = year };
                month.SetName(i);
                year.Months.Add(month);
                AddDays(month);
                _context.months.Add(month);
            }
        }
        private void AddDays(Month month)
        {
            int year = month.Year.YearNumber;
            int monthNumber = (int)month.MonthNumber;
            int daysInMonth = DateTime.DaysInMonth(year, monthNumber);

            for (int i = 1; i <= daysInMonth; i++)
            {
                var day = new Day();
                day.setup(i);
                day.Month = month;
                month.Days.Add(day);
                AssignBarbers(day);
                AssignTimeslots(day);
                _context.days.Add(day);
            }
        }
        private void AssignBarbers(Day day)
        {
            foreach (var barber in Barbers)
            {
                var barberDay = new BarberDay { Barber = barber, Day = day };
                day.BarberDays.Add(barberDay);
                barber.BarberDays.Add(barberDay);
                _context.barberDays.Add(barberDay);
            }
        }

        private void AssignTimeslots(Day day)
        {
            for (int i = 0; i < 20; i++)
            {
                foreach (var barber in Barbers)
                {
                    var timeslot = new Timeslot { Barber = barber, Day = day };
                    timeslot.setup(i);
                    day.Timeslots.Add(timeslot);
                    barber.Timeslots.Add(timeslot);
                    _context.timeslots.Add(timeslot);
                }
            }
        }
    }
}
