using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using barberdotnet.model.entities;
using barberdotnet.model.persistence;
using barberdotnet.services;
using barberdotnet.model.DTOs;

namespace barberdotnet.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeslotController : ControllerBase
    {
        private readonly ITimeslotService _timeslotService;

        public TimeslotController(ITimeslotService timeslotService)
        {
            _timeslotService = timeslotService;
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeslotDTO>> GetTimeslot(int id)
        {
            var timeslot = await _timeslotService.GetById(id);

            return timeslot;
        }

        
        [HttpGet("{year}/{month}/{day}/{hour}")]
        public async Task<ActionResult<TimeslotDTO>> GetTimeslotByExactTime(int year, int month, int day, int hour)
        {
            var timeslot = await _timeslotService.GetByExactTime(year, month, day, hour);

            return timeslot;
        }
    }
}