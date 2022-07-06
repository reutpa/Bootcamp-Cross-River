using System;
using System.Collections.Generic;
using Week2_exercise.Models;

namespace Week2_exercise.Services
{
    public class LocationService : ILocationService
    {
        private static List<PersonModel> arrPeople = new List<PersonModel>()
        {
            new PersonModel("123456789",new List<LocationModel>()
            {
            new LocationModel(new DateTime(), new DateTime(), "Jerusalem", "library"),
            new LocationModel(new DateTime(), new DateTime(), "Jerusalem", "market"),
            new LocationModel(new DateTime(), new DateTime(), "Bnei-Brak", "school"),
            }),
            new PersonModel("987654321",new List<LocationModel>(){
            new LocationModel(new DateTime(), new DateTime(), "Tzfat", "Optica"),
            new LocationModel(new DateTime(), new DateTime(), "Meron", "super-market"),
            new LocationModel(new DateTime(), new DateTime(), "Tzfat", "office"),
            })
        };
        public List<LocationModel> GetAllLocations(string city = "")
        {
            List<LocationModel> locations = new List<LocationModel>();
            arrPeople.ForEach(person =>
            {
                locations.AddRange(person.Arr.FindAll(x => x.City.ToLower().Contains(city.ToLower())));
            });
            locations.Sort((a, b) =>
            {
                if (a.StartDate < b.StartDate)
                {
                    return 1;
                }
                if (a.StartDate > b.StartDate)
                {
                    return -1;
                }
                return 0;
            });
            return locations;
        }

        public List<LocationModel> GetLocationsPerPatient(string id)
        {
            List<LocationModel> list = new List<LocationModel>();
            PersonModel p = arrPeople.Find(x => x.Id.Equals(id));
            if (p != null)
            {
                list = p.Arr;
            }
            return list;
        }
        public void AddLocation(string id, LocationModel location)
        {
            PersonModel patient = arrPeople.Find(x => x.Id.Equals(id));
            if (patient == null)
            {
                patient = new PersonModel(id);
                arrPeople.Add(patient);
            }
            patient.Arr.Add(location);
        }
        public void DeleteLocation(string id, LocationModel location)
        {
            PersonModel patient = arrPeople.Find(x => x.Id.Equals(id));
            if (patient == null)
            {
                return;
            }
            LocationModel l = patient.Arr.Find(x => x.EndDate == location.EndDate && x.StartDate == location.StartDate && x.Location == location.Location && x.City == location.City);
            //patient.Arr.RemoveAt(patient.Arr.IndexOf(l));
            patient.Arr.Remove(l);
        }
    }
}