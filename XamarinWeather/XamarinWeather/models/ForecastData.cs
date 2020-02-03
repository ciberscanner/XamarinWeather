using Newtonsoft.Json;
namespace XamarinWeather.models
{
    public class Main
    {

        [JsonProperty("temp")]
        public double temp { get; set; }

        [JsonProperty("temp_min")]
        public double temp_min { get; set; }

        [JsonProperty("temp_max")]
        public double temp_max { get; set; }

        [JsonProperty("pressure")]
        public double pressure { get; set; }

        [JsonProperty("sea_level")]
        public double sea_level { get; set; }

        [JsonProperty("grnd_level")]
        public double grnd_level { get; set; }

        [JsonProperty("humidity")]
        public int humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double temp_kf { get; set; }
    }

    public class Weather
    {

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }

        public string Link
        {
            get
            {
                return "http://openweathermap.org/img/wn/" + icon + "@2x.png";
            }
        }
    }

    public class Clouds
    {

        [JsonProperty("all")]
        public int all { get; set; }
    }

    public class Wind
    {

        [JsonProperty("speed")]
        public double speed { get; set; }

        [JsonProperty("deg")]
        public double deg { get; set; }
    }

    public class Sys
    {

        [JsonProperty("pod")]
        public string pod { get; set; }
    }

    public class Rain
    {

        [JsonProperty("3h")]
        public double h3 { get; set; }
    }

    public class Snow
    {

        [JsonProperty("3h")]
        public double h3 { get; set; }
    }

    public class WList
    {

        [JsonProperty("dt")]
        public int dt { get; set; }

        [JsonProperty("main")]
        public Main main { get; set; }

        [JsonProperty("weather")]
        public Weather[] weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }

        [JsonProperty("wind")]
        public Wind wind { get; set; }

        [JsonProperty("sys")]
        public Sys sys { get; set; }

        [JsonProperty("dt_txt")]
        public string dt_txt { get; set; }

        [JsonProperty("rain")]
        public Rain rain { get; set; }

        [JsonProperty("snow")]
        public Snow snow { get; set; }
    }

    public class Coord
    {

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lon")]
        public double lon { get; set; }
    }

    public class City
    {

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("coord")]
        public Coord coord { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }
    }

    public class ForecastData
    {

        [JsonProperty("cod")]
        public string cod { get; set; }

        [JsonProperty("message")]
        public double message { get; set; }

        [JsonProperty("cnt")]
        public int cnt { get; set; }

        [JsonProperty("list")]
        public WList[] list { get; set; }

        [JsonProperty("city")]
        public City city { get; set; }
    }

}