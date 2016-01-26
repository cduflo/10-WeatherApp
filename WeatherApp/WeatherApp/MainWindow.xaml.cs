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
                labelLocation.Content = result.full;
                labelTempF.Content = "Temperature: " + result.temperature_string;
                labelTempC.Content = "Feels Like: " + result.feelslike_string;
                labelElev.Content = "Elevation: " + result.elevation;
                labelLatLong.Content = "Latitude / Longitude: " + result.latitude + "/" + result.longitude;
                labelWindDir.Content = "Wind Direction: " + result.wind_dir;
                labelConditions.Content = result.weather;
                labelUpdate.Content = result.observation_time;
                labelHumid.Content = "Humidity: " + result.relative_humidity;
                labelVis.Content = "Visibility: " + result.visibility_mi + " miles";
                labelUV.Content = "UV: " + result.UV;
                labelPrec.Content = "Precipitation: " + result.precip_today_string;
                labelWind.Content = "Wind: " + result.wind_mph;
                imageWeather.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(result.icon + ".gif");
            }
        }
    }
}
