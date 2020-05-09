using Dentistry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dentistry.Views
{
    /// <summary>
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class ServicesAdmin : Page    {
        public ServicesAdmin()
        {
            InitializeComponent();
            DataContext = new Admin_ServicesViewModel();
            ServiceList.ItemsSource = Admin_ServicesViewModel.Services;
        }
    }
}
