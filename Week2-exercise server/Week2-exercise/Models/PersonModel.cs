using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_exercise.Models
{
    public class PersonModel
    {
        public string Id { get; set; }
        public List<LocationModel> Arr { get; set; }
        public PersonModel(string iD)
        {
            this.Id = iD;
            this.Arr = new List<LocationModel>();
        }
        public PersonModel(string id,List<LocationModel> arr)
        {
            this.Id = id;
            this.Arr = arr;
        }
        public PersonModel()
        {

        }
    }
}
