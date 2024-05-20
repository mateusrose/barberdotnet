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
        public bool IsWorkHour { get; set; } = true;
        //public string? FullTime { get; set; }


        public void setup(int i)
        {
            int baseTime = 0800;
            int increment = i * 30;

            int hours = increment / 60;
            int minutes = increment % 60;

            this.Time = baseTime + hours * 100 + minutes;
            if (Day.WeekDay == 7)
            {
                this.IsWorkHour = false;
            }
            else if ((this.Time < 1000 || this.Time >= 2000) || (this.Time >= 1300 && this.Time < 1500))
            {
                this.IsWorkHour = false;
            }
            //FullTime = this.Time+"/"+this.Day.MonthDay+"/"+this.Day.Month.MonthNumber+"/"+this.Day.Month.Year.YearNumber;
        }
    }
}