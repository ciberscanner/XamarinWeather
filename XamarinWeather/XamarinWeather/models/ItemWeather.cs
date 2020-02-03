using System;
namespace XamarinWeather.models
{
    public class ItemWeather
    {
        public string Temp { get; set; }
        public int Date { get; set; }
        public string Icon { get; set; }
        public string Day {
            get{
                if (Date == 0)
                    return DateTime.Now.DayOfWeek.ToString();
                else
                {
                    var today = DateTime.Now;
                    var nextDay = today.AddDays(Date);
                    return nextDay.DayOfWeek.ToString();
                }
            }
        }
        public string Link
        {
            get
            {
                return "http://openweathermap.org/img/wn/"+ Icon + "@2x.png";
            }
        }
    }
}
