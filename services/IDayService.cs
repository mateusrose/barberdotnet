using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.DTOs;
using barberdotnet.model.entities;
using Microsoft.AspNetCore.Mvc;

namespace barberdotnet.services
{
    public interface IDayService
    {
        Task<Day> GetById(int id);
    }
}