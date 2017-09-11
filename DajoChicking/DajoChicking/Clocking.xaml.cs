using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DajoChicking
{
    public partial class Clocking : ContentPage
    {
     
        public Clocking()
        {
            InitializeComponent();
            //Setting image to the image view based on 
            //A specific platform
           /* profileImage.Source = Device.OnPlatform(
            iOS: ImageSource.FromResource("DajoChicking.profile.png"),
            Android: ImageSource.FromResource("DajoChicking.profile.png"),
            WinPhone: ImageSource.FromResource("DajoChicking.profile.png"));*/


        }

        public void clock()
        {

        }
    }
}
