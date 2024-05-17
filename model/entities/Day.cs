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
        public int? MonthDay { get; set; }
        public Month? Month { get; set; }
        public bool CanWork { get; set; }
        public List<BarberDay>? BarberDays { get; set; } = [];
        public List<Timeslot>? Timeslots { get; set; } = [];

        public void setup(int i)
        {
            this.MonthDay = i;
            this.WeekDay = i % 7 == 0 ? 7 : i % 7;
            this.WeekDayName = this.WeekDay switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => "Error"
            };
        }





    }

}