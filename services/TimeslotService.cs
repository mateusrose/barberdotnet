using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using barberdotnet.model.persistence;
using Microsoft.AspNetCore.Mvc;

namespace barberdotnet.services
{
    public class TimeslotService : ITimeslotService
    {
        private readonly BarberContext _context;

        public TimeslotService(BarberContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Timeslot>> GetById(int id)
        {
            var timeslot = await _context.timeslots.FindAsync(id);
            
            if (timeslot == null)
            {
                throw new Exception($"Timeslot with id {id} not found");
            }
            return timeslot;
        }
    }
}