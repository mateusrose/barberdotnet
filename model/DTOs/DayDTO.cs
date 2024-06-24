using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.DTOs
{
    
    public class DayDTO
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int WeekNumber { get; set; }
        
        public string WeekDayName { get; set; }
        public int Year { get; set; }
        public List<BarberDTO> Barber { get; set; } = [];
    }
}