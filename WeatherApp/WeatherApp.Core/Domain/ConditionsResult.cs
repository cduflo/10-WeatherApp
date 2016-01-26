using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class ConditionsResult
    {
        // public string display_location { get; set; }
        // public string display_location.full { get; set; }
        // public string display_location.latitude { get; set; }
        //  public string display_location.longit { get; set; }
        //  public float display_location.elevation { get; set; }
        public string full { get; set; }
        public string latitude { get; set; }
         public string longitude { get; set; }
         public string elevation { get; set; }
        public string weather { get; set; }
        public string temperature_string { get; set; }
        public string feelslike_string { get; set; }
        public string wind_mph { get; set; }
        public string wind_dir { get; set; }
        public string relative_humidity { get; set; }
        public string visibility_mi { get; set; }
        public string UV { get; set; }
        public string precip_today_string { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string observation_time { get; set; }
    }
}
