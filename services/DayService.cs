using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.DTOs;
using barberdotnet.model.entities;
using barberdotnet.repository;
using Microsoft.AspNetCore.Mvc;

namespace barberdotnet.services
{
    public class DayService : IDayService
    {
        private readonly DayRepo _dayRepo;
        public DayService(DayRepo dayRepo)
        {
            _dayRepo = dayRepo;
        }
        public Task<Day> GetById(int id)
        {
            return _dayRepo.GetById(id);
        }
    }
}