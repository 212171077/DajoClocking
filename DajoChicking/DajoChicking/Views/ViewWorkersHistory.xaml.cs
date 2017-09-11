using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DajoChicking
{
    public partial class ViewWorkersHistory : ContentPage
    {
        public ViewWorkersHistory()
        {
            InitializeComponent();

            MainListView.ItemsSource = people;
        }

        private readonly List<Person> people = new List<Person> {
                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                }
        };
    }
}
