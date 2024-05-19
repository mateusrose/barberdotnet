using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.DTOs
{
    //shortversion to be displayed when there is a lot more information to be displayed
    public class TimeslotDTOshort
    {
        public int hour { get; set; }
        public bool isAvailable { get; set; }
        public string client { get; set; }
    }
}