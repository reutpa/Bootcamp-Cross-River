using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_exercise.Models
{
    public class LocationModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public LocationModel(DateTime start,DateTime end,string city,string location)
        {
            this.StartDate = start;
            this.EndDate = end;
            this.City = city;
            this.Location = location;
        }
        public LocationModel()
        {

        }
    }
}