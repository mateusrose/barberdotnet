using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.DTOs;
using barberdotnet.model.entities;

namespace barberdotnet.model.converter
{
    public class TSReservation
    {
        public Timeslot ToReservation(Timeslot timeslot, string client)
        {
            if (!string.IsNullOrEmpty(client))
            {
                timeslot.Client = client;
                timeslot.IsAvailable = false;
            }
            else
            {
                timeslot.Client = "";
                timeslot.IsAvailable = true;
                
            }

            return timeslot;
        }
    }
}