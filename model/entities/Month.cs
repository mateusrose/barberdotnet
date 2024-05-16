using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.entities
{
    public class Month
    {
        public int Id { get; set; }
        public int MonthNumber { get; set; }
        public string MonthName { get; set; }
        public Year Year { get; set; }
    }
}