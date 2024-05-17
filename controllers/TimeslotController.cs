using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using barberdotnet.model.entities;
using barberdotnet.model.persistence;

namespace barberdotnet.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeslotController : ControllerBase
    {
        private readonly BarberContext _context;

        public TimeslotController(BarberContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Timeslot>> GetTimeslot(int id)
        {
            var timeslot = await _context.timeslots.FindAsync(id);

            if (timeslot == null)
            {
                return NotFound();
            }

            return timeslot;
        }
    }
}