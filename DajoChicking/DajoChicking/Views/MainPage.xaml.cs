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

            if (validateUser(username, password))
            {
                /*this.DisplayAlert(
                    "Dial a Number",
                    "Login Successful...!!",
                    "Ok",
                    "Cancel");*/
<<<<<<< HEAD:DajoChicking/DajoChicking/MainPage.xaml.cs
               
                await Navigation.PushModalAsync(new WorkerTabbedPage(), false);
=======

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
>>>>>>> 4324b0641b5cdc118893b22b25bcbb56c3af229e:DajoChicking/DajoChicking/Views/MainPage.xaml.cs
                

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
    }
}
