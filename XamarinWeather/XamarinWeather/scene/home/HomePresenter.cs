using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinWeather.bases;
using XamarinWeather.models;
using XamarinWeather.network;

namespace XamarinWeather.scene.home
{
    public class HomePresenter : BasePresenter<IHomeView>
    {
        //----------------------------------------------------------------------
        //Variables
        private IHomeInteractor _interactor;
        //----------------------------------------------------------------------
        //Constructor
        public HomePresenter(IHomeView view, IHomeInteractor interactor) : base(view)
        {
            _interactor = interactor;
        }
        //----------------------------------------------------------------------
        //
        public override void Destroy()
        {
            _interactor.Destroy();
        }
        //----------------------------------------------------------------------
        //
        public override Task Init()
        {
            //View?.OnLoginButtonEnabled(true);
            return Task.FromResult(0);
        }
        //----------------------------------------------------------------------
        //
        private bool HasValidInput(string city)
        {
            return !string.IsNullOrEmpty(city);
        }
        //----------------------------------------------------------------------
        //
        public async Task searchCity(string city)
        {
            if (!HasValidInput(city))
            {
                View?.showMessage("Alert", "The city is mandatory");
                return;
            }

            View?.OnWaiting();
            Result<ForecastData> result = await _interactor.GetWeatherData(APIServer.RequestUriByCity(city));
            View?.OnStopWaiting();

            if (result.Error == Error.None)
            {
                View?.setData(result.Data);
            }
            else if (result.Error == Error.Generic)
            {
               // View?.OnInvalidInput(Strings.Nofound);
            }
        }
        //----------------------------------------------------------------------
        //
        public async Task searchByCoordenates(WCoord point)
        {
            View?.OnWaiting();
            Console.WriteLine(point.lat+ "lon: " + point.lon);
            Result<ForecastData> result = await _interactor.GetWeatherData(APIServer.RequestUriByLocation(point.lat, point.lon));
            View?.OnStopWaiting();

            if (result.Error == Error.None)
            {
                View?.setData(result.Data);
            }
            else if (result.Error == Error.Generic)
            {
                // View?.OnInvalidInput(Strings.Nofound);
            }
        }
        //----------------------------------------------------------------------
        //
        public async void getCurrenteLocation()
        {
            Result<WCoord> result = await _interactor.geCurrenteLocation();
            if (result.Error == Error.None)
            {
                await searchByCoordenates(result.Data);
            }
            else if (result.Error == Error.Generic)
            {
                // View?.OnInvalidInput(Strings.Nofound);
            }
            
        }


    }
}