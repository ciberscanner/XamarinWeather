using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinWeather.bases;
using XamarinWeather.models;

namespace XamarinWeather.scene.home
{
    public class HomeInteractor : IHomeInteractor
    {
        //----------------------------------------------------------------------
        //Variables
        HttpClient _client;
        //----------------------------------------------------------------------
        //Constructor
        public HomeInteractor()
        {
            _client = new HttpClient();
        }
        //----------------------------------------------------------------------
        //
        public void Destroy()
        {
            //would cancel api here
        }
        //----------------------------------------------------------------------
        //
        public async Task<Result<ForecastData>> GetWeatherData(string query)
        {
            ForecastData weatherData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<ForecastData>(content);
                    return new Result<ForecastData>(weatherData);
                }
                else
                {
                    return new Result<ForecastData>(Error.Generic);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
                return new Result<ForecastData>(Error.Generic);
            }
        }
        //----------------------------------------------------------------------
        //
        public async Task<Result<WCoord>> geCurrenteLocation()
        {
            var p = new WCoord {lat = "38.920853", lon ="-77.032756" };
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    p = new WCoord { lat = location.Latitude.ToString(), lon = location.Longitude.ToString() };
                    return new Result<WCoord>(p);
                }
                else
                    return new Result<WCoord>(p);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine("Error location 1");
                //return new Result<Point>(Error.Generic);
                return new Result<WCoord>(p);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                Console.WriteLine("Error location 2");
                return new Result<WCoord>(p);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine("Error location 3");
                return new Result<WCoord>(p);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine("Error location 4");
                return new Result<WCoord>(p);
            }
        }
    }
}