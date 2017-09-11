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
        private const string WebServiceUrl = "http://192.168.1.148:8080/FirstRestWebservice/rest/hello/getPerson/";
        public WorkerHistory()
        {
            InitializeComponent();
            getPersonAsync();

           
        }


        private readonly List<string> _names = new List<string> {
                "Patrick","Owami","Themba","Pat","Momelezi"
        };

   

        private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            string keyword = MainSearchBar.Text;
            IEnumerable <string>searchResult= _names.Where(name => name.ToLower().Contains(keyword.ToLower()));
            MainListView.ItemsSource = searchResult;
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