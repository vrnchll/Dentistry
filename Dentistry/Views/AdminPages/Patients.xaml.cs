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
            var patients = unitOfWork.Patients.GetAll().ToList();
            foreach(var patient in patients) {
                var user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.Id == patient.Id);
                patient.User = user;
                    }
            Admin_PatientsViewModel.Patients= new BindingList<Patient>(patients);
            InitializeComponent();
            DataContext = admincontext;
            PatientsList.ItemsSource = Admin_PatientsViewModel.Patients;
           
        }

        private void OpenSerachPanel_Click(object sender, RoutedEventArgs e)
        {
            CloseSerachPanel.Visibility = Visibility.Visible;
            OpenSerachPanel.Visibility = Visibility.Collapsed;
        }

        private void CloseSerachPanel_Click(object sender, RoutedEventArgs e)
        {
            OpenSerachPanel.Visibility = Visibility.Visible;
            CloseSerachPanel.Visibility = Visibility.Collapsed;
        }
    }
}
