using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.DAL.Models
{
    internal class Person
    {
        public string ID { get; set; }
        public List<Location> Arr { get; set; }
        public Person(string iD)
        {
            this.ID = iD;
            this.Arr = new List<Location>();
        }
        public Person(string id,List<Location> arr)
        {
            this.ID = id;
            this.Arr = arr;
        }
    }
}
