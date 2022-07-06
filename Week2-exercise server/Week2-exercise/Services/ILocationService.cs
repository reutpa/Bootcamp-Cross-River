using System.Collections.Generic;
using Week2_exercise.Models;

namespace Week2_exercise.Services
{
    public interface ILocationService
    {
        void AddLocation(string id, LocationModel location);
        List<LocationModel> GetAllLocations(string city = "");
        List<LocationModel> GetLocationsPerPatient(string id);
        void DeleteLocation(string id, LocationModel location);
    }
}