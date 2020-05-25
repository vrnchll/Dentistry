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
    /// Логика взаимодействия для Receptions.xaml
    /// </summary>
    public partial class Receptions : Page
    {
        public Receptions()
        {
            InitializeComponent();
            DataContext = new Admin_ReceptionsViewModel();
            UnitOfWork unitOfWork = new UnitOfWork();
            var receptions = unitOfWork.Receptions.GetAll().ToList();
            foreach (var rec in receptions)
            {
                var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == rec.PatientId);
                rec.Patient = patient;
                var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == rec.DoctorId);
                rec.Doctor = doctor;
                var service = unitOfWork.Services.GetAll().FirstOrDefault(x => x.Id == rec.ServiceId);
                rec.Service = service;
                Admin_ReceptionsViewModel.Receptions.Add(rec);
            }
            ReceptionList.ItemsSource = Admin_ReceptionsViewModel.Receptions;
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
