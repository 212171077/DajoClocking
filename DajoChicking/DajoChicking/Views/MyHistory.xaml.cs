using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DajoChicking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyHistory : ContentPage
    {
        public MyHistory()
        {
           
            InitializeComponent();
           
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event


            DisplayAlert("Tapped", (e.SelectedItem as Person).Name + " row was tapped", "OK");
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}