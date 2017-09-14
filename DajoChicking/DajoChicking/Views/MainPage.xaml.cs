using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DajoChicking.Models;

namespace DajoChicking
{
    public partial class MainPage : ContentPage
    {
        String username;
        String password;
        private const string WebServiceUrl = "http://192.168.1.148:8080/DajoRestWS/rest/EmployeeRest/validateEmp";
        public MainPage()
        {
            InitializeComponent();
            image.Source = Device.OnPlatform(
            iOS: ImageSource.FromResource("DajoChicking.logo.png"),
            Android: ImageSource.FromResource("DajoChicking.logo.png"),
            WinPhone: ImageSource.FromResource("DajoChicking.logo.png"));
        }

        private async void login(object sender, EventArgs e)
        {                     
           try
            {
                password = txtPassword.Text;
                username = txtUsername.Text;

                if (!String.IsNullOrEmpty(username))
                {
                    if (!String.IsNullOrEmpty(password))
                    {
                        getLoginAsync(username, password);
                    }
                    else
                    {
                        DisplayAlert("Alert", "Please enter password", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Alert", "Please enter username", "OK");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Tapped", ex.Message, "OK");
            }

        }

        private async Task getLoginAsync(string username, string password)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceUrl+"/"+username+"/"+password);

                var obj = JObject.Parse(json);
                var employeeData = obj["Employee"];
                bool status = (bool)obj["Status"];

                if (status)
                {
                    var employee = JsonConvert.DeserializeObject<Employee>(employeeData.ToString());
                    //DisplayAlert("Successfull", employeeData.ToString(), "OK");

                    if(employee.role.Equals("Admin"))
                    {
                        await Navigation.PushModalAsync(new AdminPage(employee), false);
                    }
                    else if(employee.role.Equals("genaral User"))
                    {
                        await Navigation.PushModalAsync(new WorkerTabbedPage(), false);
                    }
                }
                else 
                {
                    DisplayAlert("Else", employeeData.ToString(), "OK");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Tapped", ex.Message, "OK");
            }
        }
    }
}
