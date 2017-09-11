using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DajoChicking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerHistory : ContentPage
    {
        public List<Person> PersonList =new List<Person>();
        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoClockingWS/rest/hello/getPerson/";
        public WorkerHistory()
        {
            InitializeComponent();
            await getPersonAsync();

            //MainListView.ItemsSource = people;
        }
        
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        { 
           
        }


        private async Task getPersonAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl);
           
            var obj = JObject.Parse(json);
            var personList = (JArray)obj["List"];
            bool status= (bool)obj["Status"];

            if (status)
            {
                var data = "";
                // var plist = JsonConvert.DeserializeObject<List<Person>>(json);
                foreach (var item in personList)
                {
                    
                    data = item.ToString();
                    var person = JsonConvert.DeserializeObject<Person>(data);
                   
                    PersonList.Add(person);
                    MainListView.ItemsSource = PersonList;
                }
            }
        }

    }
}