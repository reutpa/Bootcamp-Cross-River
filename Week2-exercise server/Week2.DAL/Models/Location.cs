using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.DAL.Models
{
    internal class Location
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string LocationPlace { get; set; }
        public Location(DateTime start,DateTime end,string city,string location)
        {
            this.StartDate = start;
            this.EndDate = end;
            this.City = City;
            this.LocationPlace = location;
        }
    }
}