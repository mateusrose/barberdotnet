using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.DTOs
{
    //regular timeslotDTO
    public class TimeslotDTO
    {
        public int Hour { get; set; }
        public bool IsAvailable { get; set; }
        
        public int Day { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public string Barber { get; set; }
        public string Client { get; set;}
        public bool IsWorkHour { get; set; }
    }
}