using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week2_exercise.Models;
using Week2_exercise.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week2_exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/<location>
        [HttpGet]
        public IActionResult GetAllLocations()
        {
            try
            {
                List<LocationModel> locations = _locationService.GetAllLocations();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/<location>/Jerusalem
        [HttpGet]
        [Route("{city}")]
        public IActionResult GetLocationByCity(string city="")
        {
            try
            {
                List<LocationModel> locations = _locationService.GetAllLocations(city);
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/<location>/Jerusalem
        [HttpGet]
        [Route("GetLocationById/{id}")]
        public IActionResult GetLocationById(string id)
        {
            try
            {
                List<LocationModel> locations = _locationService.GetLocationsPerPatient(id);
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<location>/1
        [HttpPost]
        [Route("{id}")]
        public IActionResult AddLocation([FromBody] LocationModel location, string id)
        {
            try
            {
                _locationService.AddLocation(id,location);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<location>/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteLocation([FromBody] LocationModel location, string id)
        {
            try
            {
                _locationService.DeleteLocation(id, location);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
