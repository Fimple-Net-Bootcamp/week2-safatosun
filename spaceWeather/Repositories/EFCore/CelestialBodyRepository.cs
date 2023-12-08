using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using spaceWeather.Entities.Models;
using spaceWeather.Entities.RequestFeatures;
using spaceWeather.Repositories.Contracts;
using spaceWeather.Repositories.EFCore.Extensions;
using System.Xml.Linq;

namespace spaceWeather.Repositories.EFCore
{   // Functions are defined in this class to be used in repository operations.
    public class CelestialBodyRepository : ICelestialBodyRepository
    {
        //Core data is defined to be used in repository operations.
        List<CelestialBody> Data;

        public CelestialBodyRepository()
        {
            Data = new List<CelestialBody>()
            {
                new CelestialBody() { Id=  1,  Name="Mars",Temperature = 20.0},
                new CelestialBody() { Id=  2,  Name="Europa",Temperature = 50.0},
                new CelestialBody() { Id=  3,  Name="Saturn",Temperature = 80.0},
                new CelestialBody() { Id=  4,  Name="Titan",Temperature = 200.0},
                new CelestialBody() { Id = 5,  Name = "Jupiter", Temperature = 150.0 },
                new CelestialBody() { Id = 6,  Name = "Venus", Temperature = 470.0 },
                new CelestialBody() { Id = 7,  Name = "Neptune", Temperature = 200.0 },
                new CelestialBody() { Id = 8,  Name = "Mercury", Temperature = 430.0 },
                new CelestialBody() { Id = 9,  Name = "Uranus", Temperature = 224.0 },
                new CelestialBody() { Id = 10, Name = "Pluto", Temperature = 230.0 },
                new CelestialBody() { Id = 11, Name = "Earth", Temperature = 15.0 },
                new CelestialBody() { Id = 12, Name = "Ganymede", Temperature = 163.0 },
                new CelestialBody() { Id = 13, Name = "Callisto", Temperature = 183.0 },
                new CelestialBody() { Id = 14, Name = "Io", Temperature = 110.0 },
                new CelestialBody() { Id = 15, Name = "Enceladus", Temperature = 198.0 },
                new CelestialBody() { Id = 16, Name = "Triton", Temperature = 235.0 },
                new CelestialBody() { Id = 17, Name = "Ceres", Temperature = 105.0 },
                new CelestialBody() { Id = 18, Name = "Haumea", Temperature = 241.0 },
                new CelestialBody() { Id = 19, Name = "Makemake", Temperature = 243.0 },
                new CelestialBody() { Id = 20, Name = "Eris", Temperature = 243.0 },
                new CelestialBody() { Id = 21, Name = "Charon", Temperature = 220.0 },
                new CelestialBody() { Id = 22, Name = "Oberon", Temperature = 224.0 },
                new CelestialBody() { Id = 23, Name = "Miranda", Temperature = 187.0 },
                new CelestialBody() { Id = 24, Name = "Ariel", Temperature = 213.0 },
                new CelestialBody() { Id = 25, Name = "Tethys", Temperature = 187.0 }
            };
        }
        //This function returns all data according to requestParameters.
        public List<CelestialBody> GetAll(RequestParameters celestialBodyParameters)
        {
            var entities = Data
                           .FilterCelestialBodies(celestialBodyParameters.MinTemperature, celestialBodyParameters.MaxTemperature)
                           .Sort(celestialBodyParameters.OrderBy)
                           .Skip((celestialBodyParameters.PageNumber - 1) * celestialBodyParameters.PageSize)
                           .Take(celestialBodyParameters.PageSize)
                           .ToList();
                           


            return entities;
        }
        //This function returns the entity whose id value is given.
        public CelestialBody GetById(int id)
        {

            var entity = Data.Where(celestialBody => celestialBody.Id == id).SingleOrDefault();

            return entity;

        }
        //This function creates new entity.
        public void Create(CelestialBody celestialBody)
        {
            Data.Add(celestialBody);
        }
        //This function delete the entity whose id value is given.
        public void Delete(CelestialBody celestialBody)
        {
            Data.Remove(celestialBody);
        }
        //This function update the entity whose id value is given.
        public void Update(int id, CelestialBody celestialBody)
        {
            var entity = GetById(id);
            var indeks = Data.IndexOf(entity);
            Data[indeks] = celestialBody;
        }
        //This function updates the properties of the data according to the given values.
        public void Patch(CelestialBody celestialBody, JsonPatchDocument<CelestialBody> celestialBodyPatch)
        {
            celestialBodyPatch.ApplyTo(celestialBody);
        }

    }
}
