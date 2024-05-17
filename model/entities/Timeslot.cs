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
        public string Client { get; set; } = "";

        public void setup(int i)
        {
            int baseTime = 1000;
            int increment = i * 30;
           
            int hours = increment / 60;
            int minutes = increment % 60;

            this.Time = baseTime + hours * 100 + minutes;
        }
    }
}