using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.converter;
using barberdotnet.model.DTOs;
using barberdotnet.model.entities;
using barberdotnet.repository;
using Microsoft.AspNetCore.Mvc;

// A service class responsible for mana
namespace barberdotnet.services
{
    public class DayService : IDayService
    {
        private readonly DayRepo _dayRepo;
        private readonly TimeslotRepo _timeslotRepo;
        private readonly BarberRepo _barberRepo;
        private readonly TSListToDTO _listConverter;
        private readonly ILogger<DayService> _logger;
        
        public DayService(ILogger<DayService> logger ,DayRepo dayRepo, TimeslotRepo timeslotRepo, BarberRepo barberRepo, TSListToDTO listConverter)
        {
            _logger = logger;
            _barberRepo = barberRepo;
            _dayRepo = dayRepo;
            _timeslotRepo = timeslotRepo;
            _listConverter = listConverter;
        }
        
        //GET List of All BarbersDTO that contains Timeslots for the current day
        public async Task<List<BarberDTO>> GetByDate(int year, int month, int day)
        {
            var BarberDTOList = new List<BarberDTO>();

            var barbers = await _barberRepo.GetBarbers(); 
            for( int i = 1; i <= barbers.Count; i++)
            {
                BarberDTO dto = new BarberDTO();
                dto.Id = i;
                dto.Name = barbers[i-1].Name;

                List<Timeslot> timeslots = await _timeslotRepo.GetTimeslotsByDayBarber(year, month, day, i);
               

                List<TimeslotDTOshort> list = _listConverter.ToDTO(timeslots);
            _logger.LogInformation($"List: {string.Join(", ", list[1].hour)}");
                
                for(int j = 0; j < list.Count; j++)
                {
                    TimeslotDTOshort ts = list[j];
                    dto.Timeslots.Add(ts);
                    
                    //dto.Timeslots.Add((TimeslotDTOshort)list[j]);
                }
                BarberDTOList.Add(dto);
                _logger.LogInformation($"BarberDTOList: {string.Join(", ", BarberDTOList[0].Timeslots[0])}");
            }
            return BarberDTOList;
        }   
        
        public async Task<List<BarberDTO>> GetByDateBarber(int year, int month, int day, int barber)
        {
            var barberObj = await _barberRepo.GetBarberById(barber); 
            var barberDTOList = new List<BarberDTO>(); 
            
                BarberDTO dto = new BarberDTO();
                dto.Id = barberObj.Id;
                dto.Name = barberObj.Name;

                List<Timeslot> timeslots = await _timeslotRepo.GetTimeslotsByDayBarber(year, month, day, barber);
                List<TimeslotDTOshort> list = _listConverter.ToDTO(timeslots);
                
                for(int j = 0; j < list.Count; j++)
                {
                    TimeslotDTOshort ts = list[j];
                    dto.Timeslots.Add(ts);
                }
                barberDTOList.Add(dto);
                return barberDTOList;
        }   
        
            public Task<Day> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}