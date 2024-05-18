using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.DTOs
{
    public class TimeslotShortDTO : ITimeslotDTO
    {
         public int Hour { get; set; }
        public bool IsAvailable { get; set; }
    }
}