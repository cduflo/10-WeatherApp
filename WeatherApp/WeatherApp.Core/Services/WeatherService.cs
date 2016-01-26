using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Services;

namespace WeatherApp.Core.Services
{
    public class WeatherService
    {
        private static string apiKey = "b7167326a8d256d5";

        public static ConditionsResult GetWeatherFor(string zipCode)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString($"http://api.wunderground.com/api/{apiKey}/conditions/q/92109.json");
                var o = JObject.Parse(json);
                var result = new ConditionsResult();
                result.weather = o["current_observation"]["weather"].ToString();result.weather = o["current_observation"]["weather"].ToString();
                result.feelslike_string = o["current_observation"]["feelslike_string"].ToString();
                result.temperature_string = o["current_observation"]["temperature_string"].ToString();
                result.wind_mph = o["current_observation"]["wind_mph"].ToString();
                result.wind_dir = o["current_observation"]["wind_dir"].ToString();
                result.relative_humidity = o["current_observation"]["relative_humidity"].ToString();
                result.visibility_mi = o["current_observation"]["visibility_mi"].ToString();
                result.UV = o["current_observation"]["UV"].ToString();
                result.precip_today_string = o["current_observation"]["precip_today_string"].ToString();
                result.icon = o["current_observation"]["icon"].ToString();
                result.icon_url = o["current_observation"]["icon_url"].ToString();
                result.observation_time = o["current_observation"]["observation_time"].ToString();
                result.full = o["current_observation"]["display_location"]["full"].ToString();
                result.latitude = o["current_observation"]["display_location"]["latitude"].ToString();
                result.longitude = o["current_observation"]["display_location"]["longitude"].ToString();
                result.elevation = o["current_observation"]["display_location"]["elevation"].ToString();
                result.full = o["current_observation"]["display_location"]["full"].ToString();

                if (!File.Exists(result.icon+".gif"))
                {
                    using (var wcc = new WebClient())
                    {
                        byte[] bytes = wcc.DownloadData(result.icon_url);
                        File.WriteAllBytes(result.icon + ".gif", bytes);
                    }
                }

         
                

                //var result = JsonConvert.DeserializeObject<ConditionsResult>(json);
                return result;
    }
        }

    }
}
