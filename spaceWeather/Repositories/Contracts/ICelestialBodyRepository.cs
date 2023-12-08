using Microsoft.AspNetCore.JsonPatch;
using spaceWeather.Entities.Models;
using spaceWeather.Entities.RequestFeatures;

namespace spaceWeather.Repositories.Contracts
{   //This interface defines the signature of functions containing repository operations.
    public interface ICelestialBodyRepository
    {
        List<CelestialBody> GetAll(RequestParameters bookParameters);
        CelestialBody GetById(int id);
        void Create(CelestialBody celestialBody);
        void Update(int id,CelestialBody celestialBody);
        void Delete(CelestialBody celestialBody);
        void Patch(CelestialBody celestialBody, JsonPatchDocument<CelestialBody> celestialBodyPatch);
    }
}
