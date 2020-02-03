using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinWeather.models;
using XamarinWeather.network;

namespace XamarinWeather
{
    public partial class MainPage : ContentPage, ILoginView
    {
        //----------------------------------------------------------------------
        //Variables
        RestService _restService;
        public ObservableCollection<ItemWeather> weathers= new ObservableCollection<ItemWeather>();
        public ObservableCollection<ItemWeather> Weathers { get { return weathers; } }
        //----------------------------------------------------------------------
        //Constructor
        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
            geCurrenteLocation();

        }
        //----------------------------------------------------------------------
        //
        async void geCurrenteLocation() {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        //----------------------------------------------------------------------
        //
        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Aloha");
              if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
              {
                ForecastData weatherData = await _restService.GetWeatherData(APIServer.RequestUriByCity(_cityEntry.Text));
                if(weatherData== null)
                {
                    await DisplayAlert("Alert", "Not found", "OK");
                    return;
                }
                Console.WriteLine("Data: "+ weatherData.city.name + weatherData.list[1].weather[0].description);
                Console.WriteLine(DateTime.Now.DayOfWeek);
                BindingContext = weatherData;
                WeatherData(weatherData.list);
            }
            else
            {
                await DisplayAlert("Alert", "Please enter a valid city name", "OK");
            }
        }

        public void WeatherData(WList[] list)
        {
            weathers.Clear();
            WeatherForecastList.ItemsSource = weathers;
            for(int i =0; i < 7; i++)
                weathers.Add(new ItemWeather { Temp = list[i].main.temp.ToString(), Date = i, Icon = list[i].weather[0].icon });

            Console.WriteLine(weathers[0].Link);
        }

    }
}
