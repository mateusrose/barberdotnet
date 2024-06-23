using barberdotnet.model.DTOs;
using barberdotnet.model.entities;

namespace barberdotnet.model.converter;

public class DayToDTO
{
    public DayDTO ToDTO(Day day, List<BarberDTO> barbers)
    {
        DayDTO dayDTO = new DayDTO();
        dayDTO.Day = (int) day.MonthDay;
        dayDTO.Month = (int) day.Month.MonthNumber;
        dayDTO.MonthName = day.Month.MonthName;
        dayDTO.Year = day.Month.Year.YearNumber;
        dayDTO.WeekDayName = day.WeekDayName;
        dayDTO.Barber = barbers;
        
        return dayDTO;
    }
}
