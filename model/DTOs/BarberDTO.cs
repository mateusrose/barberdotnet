using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;

namespace barberdotnet.model.DTOs
{
    public class BarberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TimeslotDTOshort> Timeslots { get; set; } = [];
    }
}