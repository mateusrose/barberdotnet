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
    }
}