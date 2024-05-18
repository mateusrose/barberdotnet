using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.DTOs
{
    public class DayDTO
    {
        public List<BarberDTO> Barber { get; set; } = [];
        public int Day { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
    }
}