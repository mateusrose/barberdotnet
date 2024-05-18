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
            List<TimeslotDTOshort> timeslotDTOshorts = new List<TimeslotDTOshort>();

            foreach (Timeslot timeslot in timeslots)
            {
                TimeslotDTOshort timeslotDTOshort = new TimeslotDTOshort();
                timeslotDTOshort = _tsShortToDTO.ToDTO(timeslot);

                timeslotDTOshorts.Add(timeslotDTOshort);
            }
            return timeslotDTOshorts;
        }
    }
}