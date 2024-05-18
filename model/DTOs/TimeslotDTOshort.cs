using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.DTOs
{
    public class TimeslotDTOshort: ITimeslotDTO
    {
        public int hour { get; set; }
        public bool isAvailable { get; set; }
        public string client { get; set; }
    }
}