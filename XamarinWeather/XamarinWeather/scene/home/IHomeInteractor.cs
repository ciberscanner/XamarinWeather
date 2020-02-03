using System;
using XamarinWeather.bases;
using XamarinWeather.models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWeather.scene.home
{
    public interface IHomeInteractor : IBaseInteractor
    {
        Task<Result<ForecastData>> GetWeatherData(string query);
        Task<Result<WCoord>> geCurrenteLocation();
    }
}
