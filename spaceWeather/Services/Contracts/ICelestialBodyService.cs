using Microsoft.AspNetCore.JsonPatch;
using spaceWeather.Entities.Models;
using spaceWeather.Entities.RequestFeatures;

namespace spaceWeather.Services.Contracts
{
    //This interface defines the signature of functions containing celestialBody service functions.
    public interface ICelestialBodyService
    {
        List<CelestialBody> GetAll(RequestParameters bookParameters);
        CelestialBody GetById(int id);
        CelestialBody Create(CelestialBody celestialBody);
        void Update(int id, CelestialBody celestialBody);
        void Delete(int  id);
        void Patch(int id, JsonPatchDocument<CelestialBody> celestialBodyPatch);

    }
}
