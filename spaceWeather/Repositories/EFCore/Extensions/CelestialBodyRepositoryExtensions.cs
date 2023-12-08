using spaceWeather.Entities.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;


namespace spaceWeather.Repositories.EFCore.Extensions
{   //Special functions are defined in this class to be used in repository operations.
    public static class CelestialBodyRepositoryExtensions
    {
        //This function provides filtering feature according to the temperature values ​​it receives.
        public static List<CelestialBody> FilterCelestialBodies(this List<CelestialBody> celestialBodies, int minTemperature, uint maxTemperature) =>
            celestialBodies.Where(c => c.Temperature >= minTemperature && c.Temperature <= maxTemperature).ToList();
        
        //This function provides the ability to sort data according to the entered parameters.
        public static List<CelestialBody> Sort(this List<CelestialBody> celestialBodies, string orderByQueryString)
        {
            
            IQueryable<CelestialBody> celestialBodiesQueryable = celestialBodies.AsQueryable();

            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return celestialBodiesQueryable.OrderBy(b => b.Id).ToList();

            var orderParams = orderByQueryString.Trim().Split(',');

            var propertyInfos = typeof(CelestialBody).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];

                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase)); 

                if (objectProperty is null)
                {
                    continue;
                }

                var direction = param.EndsWith("desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");

            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return celestialBodiesQueryable.OrderBy(orderQuery).ToList();

        }

    }

}
