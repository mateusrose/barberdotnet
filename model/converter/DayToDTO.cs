using barberdotnet.model.DTOs;
using barberdotnet.model.entities;

namespace barberdotnet.model.converter;

public class DayToDTO
{
   /* public DayDTO ToDTO(Day day)
    {
        DayDTO dayDTO = new DayDTO();
        dayDTO.Day = (int) day.MonthDay;
        dayDTO.Month = (int) day.Month.MonthNumber;
        dayDTO.MonthName = day.Month.MonthName;
        dayDTO.Year = day.Month.Year.YearNumber;
        dayDTO.Barber = new List<BarberDTO>();

        foreach (Barber barber in day.BarberDays.Barber)
        {
            BarberDTO barberDTO = new BarberDTO();
            barberDTO.Id = barber.Id;
            barberDTO.Name = barber.Name;
            barberDTO.Timeslots = [];
            
            foreach (Timeslot timeslot in barber.Timeslots)
            {
                TStoDTO tsToDTO = new TStoDTO();
                barberDTO.Timeslots.Add(tsToDTO.ToDTO(timeslot));
            }
            dayDTO.Barber.Add(barberDTO);
        }
    }*/
}
