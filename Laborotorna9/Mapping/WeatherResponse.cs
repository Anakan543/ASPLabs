namespace Laborotorna9.Mapping
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public string Name {  get; set; }

        public float Visibility { get; set; }
    }

    public class TemperatureInfo
    {
        public float Temp { get; set; }
        public float Temp_min {  get; set; }
        public float Temp_max { get; set; }
        public float Feels_like { get; set;}
    }
    }

