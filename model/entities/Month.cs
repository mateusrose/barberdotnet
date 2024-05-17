using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace barberdotnet.model.entities
{
    public class Month
    {
        public int Id { get; set; }
        public int? MonthNumber { get; set; }
        public string? MonthName { get; set; }
        public Year? Year { get; set; }
        public List<Day>? Days { get; set; } = [];

    

        public void SetName(int i)
        {
            switch((i%12)){
                case 1:
                    MonthName = "January";
                    break;
                case 2:
                    MonthName = "February";
                    break;
                case 3:
                    MonthName = "March";
                    break;
                case 4:
                    MonthName = "April";
                    break;
                case 5:
                    MonthName = "May";
                    break;
                case 6:
                    MonthName = "June";
                    break;
                case 7:
                    MonthName = "July";
                    break;
                case 8:
                    MonthName = "August";
                    break;
                case 9:
                    MonthName = "September";
                    break;
                case 10:
                    MonthName = "October";
                    break;
                case 11:
                    MonthName = "November";
                    break;
                case 0:
                    MonthName = "December";
                    break;
            }
        }


    }


}