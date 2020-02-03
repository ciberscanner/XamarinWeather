using System;
using XamarinWeather.bases;
using XamarinWeather.models;

namespace XamarinWeather.scene.home
{
    public interface IHomeView: IBaseView
    {
        void OnGetWeatherButtonClicked(object sender, EventArgs e);
        void getCurrenteLocation();

        void showMessage(string title, string message);
        void setData(ForecastData wData);

        void OnWaiting();
        void OnStopWaiting();
    }
}
