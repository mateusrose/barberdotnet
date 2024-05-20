using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.DTOs;
using barberdotnet.model.entities;

namespace barberdotnet.model.converter
{
    public class TSshortToDTO
    {
        public TimeslotDTOshort ToDTO(Timeslot timeslot)
        {
            TimeslotDTOshort timeslotDTOshort = new TimeslotDTOshort();
         

            timeslotDTOshort.hour = (int) timeslot.Time;
            timeslotDTOshort.isAvailable = timeslot.IsAvailable;
            timeslotDTOshort.client = timeslot.Client;
            timeslotDTOshort.IsWorkHour = timeslot.IsWorkHour;
            return timeslotDTOshort;
        }
    }
}