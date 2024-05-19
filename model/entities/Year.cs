using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using barberdotnet.model.entities;

namespace barberdotnet.model
{
    
public class Year
{
    public int Id { get; set; }
    public int YearNumber { get; set; }

    private static int MaxYear = 2024;
    public List<Month> Months { get; set; } = [];

    public Year()
    {
        YearNumber = MaxYear++;
        
    }
}
}