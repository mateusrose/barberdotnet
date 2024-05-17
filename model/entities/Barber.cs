using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.entities
{
    public class Barber
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<BarberDay>? BarberDays { get; set; } = [];
       // public List<TimeSlot>? TimeSlots { get; set; } = [];

    }
}