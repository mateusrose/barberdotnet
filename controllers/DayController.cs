using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using barberdotnet.services;
using barberdotnet.model.DTOs;

namespace barberdotnet.controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DayController
    {
        private readonly IDayService _dayService;
        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDayById(int id)
        {
            var day = await _dayService.GetById(id);

            return day;
        }

        [HttpGet("{year}/{month}/{day}")]
        public async Task<ActionResult<List<BarberDTO>>> GetDayByDate(int year, int month, int day)
        {
            var barberList = await _dayService.GetByDate(year, month, day);

            return barberList;
        }
        [HttpGet("{year}/{month}/{day}/info")]
        public async Task<DayDTO> GetDayByDateBasic(int year, int month, int day)
        {
            var dayDto = await _dayService.GetDayByDateBasic(year, month, day);
            return dayDto;
        }
    }
}