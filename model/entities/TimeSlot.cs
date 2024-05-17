using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.entities
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public int? Time { get; set; }
        public bool IsAvailable { get; set; }
    }
}