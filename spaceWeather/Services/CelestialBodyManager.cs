using Microsoft.AspNetCore.JsonPatch;
using spaceWeather.Entities.Models;
using spaceWeather.Entities.RequestFeatures;
using spaceWeather.Repositories.Contracts;
using spaceWeather.Services.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace spaceWeather.Services
{   //Service functions are defined to manage celestialBody operations.
    public class CelestialBodyManager : ICelestialBodyService
    {

        private readonly ICelestialBodyRepository celestialBodyRepository;

        public CelestialBodyManager(ICelestialBodyRepository celestialBodyRepository)
        {
            this.celestialBodyRepository = celestialBodyRepository;
        }
        //This function returns all data according to requestParameters. 
        public List<CelestialBody> GetAll(RequestParameters bookParameters)
        {
            var entities = celestialBodyRepository.GetAll(bookParameters);
            return entities;
        }
        //This function returns the entity whose id value is given.
        public CelestialBody GetById(int id)
        {
            var celestialBody = GetByIdAndCheckExits(id);
            return celestialBody;
        }
        //This function creates new entity.
        public CelestialBody Create(CelestialBody celestialBody)
        {
            celestialBodyRepository.Create(celestialBody);

            return GetById(celestialBody.Id);   
        }
        //This function update the entity whose id value is given.
        public void Update(int id, CelestialBody celestialBody)
        {
            if (id != celestialBody.Id)
                throw new Exception("Id values ​​are not equal.");

            var entity = GetByIdAndCheckExits(id);
            celestialBodyRepository.Update(entity.Id, celestialBody);

        }
        //This function delete the entity whose id value is given.
        public void Delete(int id)
        {
            var entity = GetByIdAndCheckExits(id);
            celestialBodyRepository.Delete(entity);
        }
        //This function updates the properties of the data according to the given values.
        public void Patch(int id, JsonPatchDocument<CelestialBody> celestialBodyPatch)
        {
            var entity = GetByIdAndCheckExits(id);
            celestialBodyRepository.Patch(entity,celestialBodyPatch);
        }
        //This function checks whether an entity exists or not according to the given id parameter.
        private CelestialBody GetByIdAndCheckExits(int id)
        {

            var entity = celestialBodyRepository.GetById(id);

            if (entity is null)
            {
                throw new Exception($"No celestialBody object with ID number {id} was found.");
            }

            return entity;
        }

        
    }
}
