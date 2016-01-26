using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.Core.Services;
using WeatherApp.Core;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonQuery_Click(object sender, RoutedEventArgs e)
        {
            string query = textBoxQuery.Text;
            ConditionsResult result = WeatherService.GetWeatherFor(query);

            if (result == null)
            {
                MessageBox.Show(WeatherService.message);
            }
            else
            {
                labelLocation.Content = result.current_observation.display_location.full;
                labelTempF.Content = "Temperature: " + result.current_observation.temperature_string;
                labelTempC.Content = "Feels Like: " + result.current_observation.feelslike_string;
                labelElev.Content = "Elevation: " + result.current_observation.display_location.elevation;
                labelLatLong.Content = "Latitude / Longitude: " + result.current_observation.display_location.latitude + "/" + result.current_observation.display_location.longitude;
                labelWindDir.Content = "Wind Direction: " + result.current_observation.wind_dir;
                labelConditions.Content = result.current_observation.weather;
                labelUpdate.Content = result.current_observation.observation_time;
                labelHumid.Content = "Humidity: " + result.current_observation.relative_humidity;
                labelVis.Content = "Visibility: " + result.current_observation.visibility_mi + " miles";
                labelUV.Content = "UV: " + result.current_observation.UV;
                labelPrec.Content = "Precipitation: " + result.current_observation.precip_today_string;
                labelWind.Content = "Wind: " + result.current_observation.wind_mph;
                imageWeather.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(result.current_observation.icon + ".gif");
            }
        }
    }
}
