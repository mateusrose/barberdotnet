using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.tables;

namespace barberdotnet.model.entities
{
    public class Day
    {
        public int Id { get; set; }
        public int? WeekDay { get; set; }
        public string? WeekDayName { get; set; }
        public int? WeekNumber { get; set; }
        public int? MonthDay { get; set; }
        public Month? Month { get; set; }
        public bool CanWork { get; set; } = true;
        public List<BarberDay>? BarberDays { get; set; } = [];
        public List<Timeslot>? Timeslots { get; set; } = [];

        public void Setup(int i, int weekDay, int weekNumber)
        {
            this.MonthDay = i;
            this.WeekDay = weekDay;
            this.WeekNumber = weekNumber;
            this.WeekDayName = this.WeekDay switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                0 => "Sunday",
                _ => "Error"
            };
            if (this.WeekDayName.Equals("Sunday"))
            {
                CanWork = false;
            } 
        }





    }

}