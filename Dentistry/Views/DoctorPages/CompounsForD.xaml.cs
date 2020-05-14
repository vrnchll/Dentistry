using Dentistry.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dentistry.Views.DoctorPages
{
    /// <summary>
    /// Логика взаимодействия для CompounsForD.xaml
    /// </summary>
    public partial class CompounsForD : Page
    {
        public CompounsForD()
        {
            InitializeComponent();
            DataContext = new Admin_CompounsViewModel();

            CompounsList.ItemsSource = Admin_CompounsViewModel.Compouns;
            UnitOfWork unitOfWork = new UnitOfWork();

            var compouns = unitOfWork.Compouns.GetAll().Where(x => x.DoctorId == Account.GetInstance().Id).ToList();
            foreach (var compoun in compouns)
            {
                var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == compoun.PatientId);
                compoun.Patient =  patient;
                var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == compoun.DoctorId);
                compoun.Doctor = doctor;
                Admin_CompounsViewModel.Compouns.Add(compoun);
            }
     

        }



    }
}
