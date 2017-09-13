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
<<<<<<< HEAD
        public List<Person> PersonList = new List<Person>();
        private const string WebServiceUrl = "http://192.168.1.148:8080/FirstRestWebservice/rest/hello/getPerson/";
        public WorkerHistory()
        {
            InitializeComponent();
            getPersonAsync();
=======
        public List<Person> PersonList =new List<Person>();
        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoClockingWS/rest/hello/getPerson/";
        public WorkerHistory()
        {
            InitializeComponent();
            await getPersonAsync();

>>>>>>> 90eb65c7715d38ca972dec29c5430c247e5fd975
            //MainListView.ItemsSource = people;
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        { 
<<<<<<< HEAD
        }


        private readonly List<string> _names = new List<string> {
                "Patrick","Owami","Themba","Pat","Momelezi"
        };

   

        private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event

      
            DisplayAlert("Tapped", (e.SelectedItem as Person).Name + " row was tapped", "OK" );
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
     

=======
           
        }


>>>>>>> 90eb65c7715d38ca972dec29c5430c247e5fd975
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
<<<<<<< HEAD
=======

>>>>>>> 90eb65c7715d38ca972dec29c5430c247e5fd975
    }
}