using DajoChicking.ViewModels;
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
    public partial class ViewWorkersHistory : ContentPage
    {
        public List<Person> peopleList = new List<Person>();
        public List<Person> PersonList = new List<Person>();
        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoClockingWS/rest/hello/getPerson/";
        public ViewWorkersHistory()
        {
           // peopleList = MainViewModel.peopleList;
            InitializeComponent();
            getPersonAsync();
            //MainListView.ItemsSource = people;
        }

        private async Task getPersonAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var obj = JObject.Parse(json);
            var personList = (JArray)obj["List"];
            bool status = (bool)obj["Status"];

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

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event

            await Navigation.PushModalAsync(new Views.MyHistory(), false);

            // DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }



        private void SearchBar_OnTextChanged(object sender, EventArgs e)
        {
            string keyword = MainSearchBar.Text;
            // IEnumerable <string>searchResult= _names.Where(name => name.ToLower().Contains(keyword.ToLower()));
            //MainListView.ItemsSource = searchResult;

        }


        private void FilterNames()
        {
            string filter = MainSearchBar.Text;
            MainListView.BeginRefresh();
            if (string.IsNullOrWhiteSpace(filter))
            {
                MainListView.ItemsSource = peopleList;
            }
            else
            {
                MainListView.ItemsSource = peopleList.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
            }
            MainListView.EndRefresh();
        }
        void OnSearchBarTextChanged(object sender, TextChangedEventArgs args)
        {
            FilterNames();
        }
        void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            FilterNames();
        }
    }
}
