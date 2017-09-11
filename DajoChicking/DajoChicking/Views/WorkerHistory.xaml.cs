using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DajoChicking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerHistory : ContentPage
    {
        public WorkerHistory()
        {
            InitializeComponent();

            MainListView.ItemsSource = people;
        }


        private readonly List<string> _names = new List<string> {
                "Patrick","Owami","Themba","Pat","Momelezi"
        };

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

        private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            string keyword = MainSearchBar.Text;
            IEnumerable <string>searchResult= _names.Where(name => name.ToLower().Contains(keyword.ToLower()));
            MainListView.ItemsSource = searchResult;
        }
    }
}