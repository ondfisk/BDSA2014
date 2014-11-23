using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
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
using Newtonsoft.Json;

namespace Lecture07.Async
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

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;

            var amount = double.Parse(DKK.Text);
            
            var usd = await GetRate("DKK", "USD");
            USD.Content = (amount * usd).ToString("N2");

            var gbp = await GetRate("DKK", "GBP");
            GBP.Content = (amount * gbp).ToString("N2");

            var eur = await GetRate("DKK", "EUR");
            EUR.Content = (amount * eur).ToString("N2");

            (sender as Button).IsEnabled = true;
        }

        private async Task<double> GetRate(string from, string to)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            using (var client = new WebClient())
            {
                var urlString = string.Format("http://jsonrates.com/get/?from={0}&to={1}", from, to);
                var url = new Uri(urlString);

                try
                {
                    var data = await client.DownloadStringTaskAsync(url);

                    var json = JsonConvert.DeserializeObject<ExchangeRate>(data);

                    return json.Rate;
                }
                catch
                {
                    return double.NaN;
                }
            }
        }
    }

    public class ExchangeRate
    {
        public DateTime UtcTime { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public double Rate { get; set; }
    }
}
