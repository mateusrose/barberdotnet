using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;

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
            DBInit();
            AddYears(2);

            _context.SaveChanges();
        }
        private void DBInit()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        private void AddYears(int years)
        {
            for(int i = 0; i < years; i++)
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
            }
        }
    }
}