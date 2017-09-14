using DajoChicking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DajoChicking
{
    public partial class AdminPage : TabbedPage
    {
        public static Employee emp = new Employee();
        public AdminPage(Employee employee)
        {
            InitializeComponent();
            emp = employee;
           
        }

    }
}
