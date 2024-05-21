using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.DTOs;
using barberdotnet.model.entities;
using Microsoft.AspNetCore.Mvc;

namespace barberdotnet.model.converter
{
    public class TSListToDTO
    {
        private readonly TSshortToDTO _tsShortToDTO;
        public TSListToDTO(TSshortToDTO tsShortToDTO)
        {
            _tsShortToDTO = tsShortToDTO;
        }
        public List<TimeslotDTOshort> ToDTO(List<Timeslot> timeslots)
        {
           var timeslotDTOshorts  = timeslots.Select(_tsShortToDTO.ToDTO).ToList();
            return timeslotDTOshorts;
        }
    }
}