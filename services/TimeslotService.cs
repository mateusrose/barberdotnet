using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using barberdotnet.model.persistence;
using Microsoft.AspNetCore.Mvc;
using barberdotnet.model.DTOs;
using Microsoft.EntityFrameworkCore;
using barberdotnet.model.converter;
using barberdotnet.repository;

namespace barberdotnet.services
{
    public class TimeslotService : ITimeslotService
    {
        private readonly BarberContext _context;
        private readonly TStoDTO _converter;
        private readonly TimeslotRepo _repository;
        private readonly TSReservation _tsConverter;
        public TimeslotService(BarberContext context, TStoDTO converter, TimeslotRepo repository, TSReservation tsConverter)
        {
            _tsConverter = tsConverter;
            _context = context;
            _converter = converter;
            _repository = repository;
        }

        public async Task<ActionResult<TimeslotDTO>> GetById(int id)
        {
            var timeslot = await _repository.GetById(id);

            TimeslotDTO dto = _converter.ToDTO(timeslot);

            if (timeslot == null)
            {
                throw new Exception($"Timeslot with id {id} not found");
            }
            return dto;
        }
        public async Task<ActionResult<TimeslotDTO>> GetByExactTime(int year, int month, int day, int hour, int barber)
        {
            var timeslot = await _repository.GetByExactTime(year, month, day, hour, barber);

            TimeslotDTO dto = _converter.ToDTO(timeslot);

            if (timeslot == null)
            {
                throw new Exception($"Timeslot with year {year}, month {month}, day {day}, hour {hour} and barber {barber} not found");
            }
            return dto;
        }


        public async Task<ActionResult<TimeslotDTO>> SetReservation(int year, int month, int day, int hour, int barber, string client)
        {
            var timeslot = await _repository.GetByExactTime(year, month, day, hour, barber);

            if (timeslot == null)
            {
                throw new Exception($"Timeslot with year {year}, month {month}, day {day}, hour {hour} and barber {barber} not found");
            }

            timeslot = _tsConverter.ToReservation(timeslot, client);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return _converter.ToDTO(timeslot);
        }
    }
}