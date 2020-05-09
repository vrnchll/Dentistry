using Dentistry.Models;
using Dentistry.Services;
using Dentistry.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для Patients.xaml
    /// </summary>
    public partial class Patients : Page
    {
        public Patients()
        {
            Admin_PatientsViewModel admincontext =  new Admin_PatientsViewModel();
            UnitOfWork unitOfWork = new UnitOfWork();
            Admin_PatientsViewModel.Patients= new BindingList<Patient>(unitOfWork.Patients.GetAll().ToList());
            InitializeComponent();
            DataContext = admincontext;
            PatientsList.ItemsSource = Admin_PatientsViewModel.Patients;

        }
    }
}
