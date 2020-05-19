using Dentistry.Models;
using Dentistry.ViewModels;
using Dentistry.ViewModels.AdminPagesViewModel;
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
    /// Логика взаимодействия для AddNewDoctor.xaml
    /// </summary>
    public partial class AddNewDoctor : Window
    {
        public AddNewDoctor(Doctor doctor = null)
        {
            InitializeComponent();
            DataContext = new DoctorViewModel(doctor);
        }
    }
}
