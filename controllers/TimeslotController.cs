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
using Microsoft.AspNetCore.Authorization;

namespace barberdotnet.controllers
{
    [Authorize]
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


        [HttpGet("{year}/{month}/{day}/{hour}/{barber}")]
        public async Task<ActionResult<TimeslotDTO>> GetTimeslotByExactTime(int year, int month, int day, int hour, int barber)
        {
            var timeslot = await _timeslotService.GetByExactTime(year, month, day, hour, barber);

            return timeslot;
        }

        [HttpGet("{year}/{month}/{day}/{hour}/{barber}/{client}")]
        public async Task<ActionResult<TimeslotDTO>> SetReservation(int year, int month, int day, int hour, int barber, string client)
        {
            var timeslot = await _timeslotService.SetReservation(year, month, day, hour, barber, client);

            return timeslot;
        }
        
         [HttpGet("{year}/{month}/{day}/{hour}/{barber}/clear")]
        public async Task<ActionResult<TimeslotDTO>> SetReset(int year, int month, int day, int hour, int barber)
        {
            string client = "";
            var timeslot = await _timeslotService.SetReservation(year, month, day, hour, barber, client);

            return timeslot;
        }


        [HttpGet("{year}/{month}/{day}/{barber}")]
        public async Task<ActionResult<List<TimeslotDTOshort>>> GetTimeslotsByDayBarber(int year, int month, int day,  int barber)
        {
            var timeslots = await _timeslotService.GetTimeslotsByDay(year, month, day, barber);

            return timeslots;
        }
    }
}