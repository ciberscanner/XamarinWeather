using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinWeather.models;
using XamarinWeather.scene.home;

namespace XamarinWeather
{
    public partial class MainPage : ContentPage, IHomeView
    {
        //----------------------------------------------------------------------
        //Variables
        ObservableCollection<ItemWeather> weathers = new ObservableCollection<ItemWeather>();
        HomePresenter _presenter;
        HomeInteractor _interactor;
        //----------------------------------------------------------------------
        //Constructor
        public MainPage()
        {
            InitializeComponent();
            _interactor = new HomeInteractor();
            _presenter = new HomePresenter(this, _interactor);
            getCurrenteLocation();
        }
        //----------------------------------------------------------------------
        //
        public void getCurrenteLocation()
        {
             _presenter.getCurrenteLocation();
        }
        //----------------------------------------------------------------------
        //
        public async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            await _presenter.searchCity(_cityEntry.Text);
        }
        //----------------------------------------------------------------------
        //
        public void setData(ForecastData wData)
        {
            BindingContext = wData;
            weathers.Clear();
            WeatherForecastList.ItemsSource = weathers;
            for (int i = 0; i < 7; i++)
                weathers.Add(new ItemWeather { Temp = wData.list[i].main.temp.ToString(), Date = i, Icon = wData.list[i].weather[0].icon });
        }
        //----------------------------------------------------------------------
        //
        public async void showMessage(string title, string message)
        {
            await DisplayAlert(title, message, "OK");
        }
        //----------------------------------------------------------------------
        //
        public void OnNetworkError(){ }
        //----------------------------------------------------------------------
        //
        public void OnWaiting(){ }
        //----------------------------------------------------------------------
        //
        public void OnStopWaiting() { }
    }
}