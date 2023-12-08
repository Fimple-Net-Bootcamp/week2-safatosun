using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using spaceWeather.Entities.Models;
using spaceWeather.Entities.RequestFeatures;
using spaceWeather.Repositories.EFCore;
using spaceWeather.Services.Contracts;

namespace spaceWeather.Controllers
{
    [Route("api/v1/celestialbodies")]
    [ApiController]
    //Actions on the CelestialBody entity can be used by making a request to this class.
    public class CelestialBodyController : ControllerBase
    {
        private readonly ICelestialBodyService _celestialBodyService;

        public CelestialBodyController(ICelestialBodyService celestialBodyService)
        {
            _celestialBodyService = celestialBodyService;
        }
        //This function returns all data with the appropriate status code based on the request parameters.
        [HttpGet]
        public IActionResult GetAll([FromQuery]RequestParameters requestParameters)
        {

           var entities = _celestialBodyService.GetAll(requestParameters);
           return Ok(entities);    

        }
        //This function returns the entity whose id value is given with the appropriate status code.
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {

            var celestialBody = _celestialBodyService.GetById(id);
            return Ok(celestialBody);             

        }
        //This function creates new entity and return it with the appropriate status code.
        [HttpPost]
        public IActionResult Create([FromBody] CelestialBody celestialBody)
        {
            var createdCelestialBody = _celestialBodyService.Create(celestialBody);
            return CreatedAtAction(nameof(GetById), new { id = createdCelestialBody.Id }, createdCelestialBody);
        }
        //This function update the entity whose id value is given  and return appropriate status code.
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody] CelestialBody celestialBody)
        {
             
             _celestialBodyService.Update(id, celestialBody);
             return Ok();
             
        }
        //This function delete the entity whose id value is given with  and return appropriate status code.
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            
            _celestialBodyService.Delete(id);
            return NoContent();
            
        }
        //This function updates the properties of the data according to the given values and return appropriate status code..
        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute] int id, JsonPatchDocument<CelestialBody> celestialBodyPatch)
        {
            _celestialBodyService.Patch(id, celestialBodyPatch);
            return Ok();
        }


    }
}
