using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;
using Microsoft.AspNetCore.Mvc;
using barberdotnet.model.DTOs;

namespace barberdotnet.services
{
    public interface ITimeslotService
    {
        Task<ActionResult<TimeslotDTO>> GetById(int id);
        Task<ActionResult<TimeslotDTO>> GetByExactTime(int year, int month, int day, int hour, int barber);
        Task<ActionResult<TimeslotDTO>> SetReservation(int year, int month, int day, int hour, int barber, string client);
    }
}