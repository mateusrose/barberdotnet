using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.entities
{
    public class Timeslot
    {
        public int Id { get; set; }
        public double Time { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Barber? Barber { get; set; }
        public Day? Day { get; set; }

        public void setup(double i)
        {
            this.Time = i;
            this.Time = 10 + i / 2;
        }
    }
}