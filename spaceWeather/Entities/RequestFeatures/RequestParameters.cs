namespace spaceWeather.Entities.RequestFeatures
{   //This class represents the parameters that can be used when making requests.
    public class RequestParameters
    {
        public int PageNumber { get; set; }
        public int PageSize   { get; set; }
        public int MinTemperature { get; set; }
        public uint MaxTemperature { get; set; } 
        public String? OrderBy { get; set; }

    }
}
