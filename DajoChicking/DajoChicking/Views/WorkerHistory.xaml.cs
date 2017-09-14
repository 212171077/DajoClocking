using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DajoChicking.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DajoChicking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerHistory : ContentPage
    {
        public Employee employee = AdminPage.emp;
        public List<Clocking> Clockings = new List<Clocking>();
        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoRestWS/rest/ClockingRest/getAllByID/93042496082082";

        public WorkerHistory()
        {
            InitializeComponent();
            DisplayAlert("Displaying Employee", employee.name, "OK");
            getClockingAsync();
        }
        
        private async Task getClockingAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceUrl);

                var obj = JObject.Parse(json);
                var tempClockings = (JArray)obj["Clockings"];
                bool status = (bool)obj["Status"];

                if (status)
                {
                    var data = "";
                    // var plist = JsonConvert.DeserializeObject<List<Person>>(json);
                    foreach (var item in tempClockings)
                    {
                        data = item.ToString();
                        var clocking = JsonConvert.DeserializeObject<Clocking>(data);
                        Clockings.Add(clocking);

                        // DisplayAlert("Tapped", data, "OK");
                        MainListView.ItemsSource = Clockings;
                    }
                }
                else
                {
                    var label = new Label { Text = "No History available.", TextColor = Color.FromHex("#77d065"), FontSize = 30, TranslationY = 30 };
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Tapped", ex.Message, "OK");
            }
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event

            //await Navigation.PushModalAsync(new Views.MyHistory(e.SelectedItem as Clocking), false);

             DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}