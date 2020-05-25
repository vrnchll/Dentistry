using Dentistry.Services;
using Dentistry.ViewModels;
using Dentistry.ViewModels.DoctorPagesViewModel;
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
    public partial class ReceptionsForD : Page
    {
        public ReceptionsForD()
        {
            InitializeComponent();
            DataContext = new ReceptionsForDViewModel();
            UnitOfWork unitOfWork = new UnitOfWork();
            var receptions = unitOfWork.Receptions.GetAll().Where(x => x.DoctorId == Account.GetInstance().Id).ToList();
            foreach (var rec in receptions)
            {
                var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == rec.PatientId);
                rec.Patient = patient;
                var service = unitOfWork.Services.GetAll().FirstOrDefault(x => x.Id == rec.ServiceId);
                rec.Service = service;
                ReceptionsForDViewModel.Receptions.Add(rec);
            }
            ReceptionList.ItemsSource = ReceptionsForDViewModel.Receptions;
        }
    }
}
