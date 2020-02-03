using System;
namespace XamarinWeather.network
{
    public static class APIServer
    {
        //----------------------------------------------------------------------
        //Variables
        public static string urlServer = "https://api.openweathermap.org/data/2.5/forecast";
        public static string keyAPI = "b266f36961c7eacd50fc8ef5afc3b03a";
        //----------------------------------------------------------------------
        //
        public static string RequestUriByCity(string city)
        {
            string requestUri = urlServer;
            requestUri += $"?q={city}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={keyAPI}";
            return requestUri;
        }
        //----------------------------------------------------------------------
        //
        public static string RequestUriByLocation(string lat, string lon)
        {
            string requestUri = urlServer;
            requestUri += $"?lat={lat}&lon={lon}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={keyAPI}";
            Console.WriteLine(requestUri);
            return requestUri;
        }
    }
}
