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
<<<<<<< HEAD
                password = txtPassword.Text;
                username = txtUsername.Text;
=======
                /*this.DisplayAlert(
                    "Dial a Number",
                    "Login Successful...!!",
                    "Ok",
                    "Cancel");*/
<<<<<<< HEAD
               
                await Navigation.PushModalAsync(new WorkerTabbedPage(), false);

=======

               
                await Navigation.PushModalAsync(new WorkerTabbedPage(), false);
>>>>>>> 90eb65c7715d38ca972dec29c5430c247e5fd975
>>>>>>> 845d16acbe932f605e3fab1f3ade93047cf29c04

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
<<<<<<< HEAD
=======
                else {
                    this.DisplayAlert(
                   "Invalid User",
                   "Please enter A or W as username",
                   "Ok",
                   "Cancel");
                }
<<<<<<< HEAD
=======

>>>>>>> 90eb65c7715d38ca972dec29c5430c247e5fd975
                

>>>>>>> 845d16acbe932f605e3fab1f3ade93047cf29c04
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
