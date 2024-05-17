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

        public TimeslotService(BarberContext context)
        {   
            _context = context;
            _converter = new TStoDTO();
            _repository = new TimeslotRepo(context);
            
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
    }
}