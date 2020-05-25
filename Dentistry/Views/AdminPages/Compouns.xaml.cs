using Dentistry.Services;
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
    /// Логика взаимодействия для Compouns.xaml
    /// </summary>
    public partial class Compouns : Page
    {
        public Compouns()
        {
            InitializeComponent();
            DataContext = new Admin_CompounsViewModel();
          
            UnitOfWork unitOfWork = new UnitOfWork();
            var compouns = unitOfWork.Compouns.GetAll().ToList();
            foreach (var compoun in compouns)
            {
                var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == compoun.PatientId);
                compoun.Patient = patient;
                var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == compoun.DoctorId);
                compoun.Doctor = doctor;
                Admin_CompounsViewModel.Compouns.Add(compoun);
            }
            CompounsList.ItemsSource = Admin_CompounsViewModel.Compouns;

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
