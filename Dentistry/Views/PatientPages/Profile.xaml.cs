using Dentistry.Services;
using Dentistry.ViewModels;
using Dentistry.ViewModels.PatientPagesViewModel;
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

namespace Dentistry.Views.PatientPages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            DataContext = new PatientProfileViewModel();
            CompounsList.ItemsSource = PatientProfileViewModel.Compouns;
            UnitOfWork unitOfWork = new UnitOfWork();
            var compouns = unitOfWork.Compouns.GetAll().Where(x => x.PatientId == Account.GetInstance().Id).ToList();
            foreach (var compoun in compouns)
            {
                var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == compoun.DoctorId);
                compoun.Doctor = doctor;
                PatientProfileViewModel.Compouns.Add(compoun);
            }

        }
    }
}
