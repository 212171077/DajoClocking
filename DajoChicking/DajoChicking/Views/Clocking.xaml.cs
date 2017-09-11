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
<<<<<<< HEAD:DajoChicking/DajoChicking/Clocking.xaml.cs
           /* profileImage.Source = Device.OnPlatform(
=======
           
            profileImage.Source = Device.OnPlatform(
>>>>>>> 4324b0641b5cdc118893b22b25bcbb56c3af229e:DajoChicking/DajoChicking/Views/Clocking.xaml.cs
            iOS: ImageSource.FromResource("DajoChicking.profile.png"),
            Android: ImageSource.FromResource("DajoChicking.profile.png"),
            WinPhone: ImageSource.FromResource("DajoChicking.profile.png"));*/


        }

        public void clock()
        {

        }
    }
}
