using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;

namespace barberdotnet.model.tables
{
    public class BarberDay
    {
        public int BarberId { get; set; }
        public Barber Barber { get; set; }
        public int DayId { get; set; }
        public Day Day { get; set; }
    }
}