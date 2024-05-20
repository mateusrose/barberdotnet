using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using barberdotnet.model.DTOs;

namespace barberdotnet.model.converter
{
    public class TStoDTO
    {
        public TimeslotDTO ToDTO(Timeslot timeslot)
        {
            TimeslotDTO dto = new TimeslotDTO()
            {
                Hour = (int)timeslot.Time,
                IsAvailable = timeslot.IsAvailable,
                Day = (int)timeslot.Day.MonthDay,
                Month = (int)timeslot.Day.Month.MonthNumber,
                MonthName = timeslot.Day.Month.MonthName,
                Year = timeslot.Day.Month.Year.Id,
                Barber = timeslot.Barber.Name,
                Client = timeslot.Client,
                IsWorkHour = timeslot.IsWorkHour
            };
            return dto;
        }
    }
}