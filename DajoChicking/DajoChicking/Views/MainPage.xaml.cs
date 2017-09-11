﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DajoChicking
{
    public partial class MainPage : ContentPage
    {
        String username;
        String password;
        public List<String> helloList { get; set; }


        public MainPage()
        {
            InitializeComponent();
           
            //Setting image to the image view based on 
            //A specific platform
            image.Source = Device.OnPlatform(
            iOS: ImageSource.FromResource("DajoChicking.logo.png"),
            Android: ImageSource.FromResource("DajoChicking.logo.png"),
            WinPhone: ImageSource.FromResource("DajoChicking.logo.png"));
        }

        private async void login(object sender, EventArgs e)
        {
            password = txtPassword.Text;
            username = txtUsername.Text;
            //getHelloAsync();

            if (validateUser(username, password))
            {
                /*this.DisplayAlert(
                    "Dial a Number",
                    "Login Successful...!!",
                    "Ok",
                    "Cancel");*/

               
                await Navigation.PushModalAsync(new WorkerTabbedPage(), false);

                if (username.Equals("A"))
                {
                    await Navigation.PushModalAsync(new AdminPage(), false);
                }
                else if (username.Equals("W"))
                {
                    await Navigation.PushModalAsync(new WorkerTabbedPage(), false);
                }
                else {
                    this.DisplayAlert(
                   "Invalid User",
                   "Please enter A or W as username",
                   "Ok",
                   "Cancel");
                }

                

            }
            else
            {
                this.DisplayAlert(
                    "Dial a Number",
                    "Login Failed...!!",
                    "Ok",
                    "Cancel");
            }
           
        }

        public Boolean validateUser(String username,String password)
        {
            Boolean isValidateUser = true;

            if(username.Length==0 || password.Length==0)
            {
                isValidateUser = false;
            }
            return isValidateUser;

        }

        /*private async Task getHelloAsync()
        {
            var dajoClockingService = new Services.DajoClockingService();
            helloList = await dajoClockingService.getHelloAsync();
            this.DisplayAlert(
                  "Hello",
                  "Data :" + helloList,
                  "Ok",
                  "Cancel");
        }*/
    }
}
