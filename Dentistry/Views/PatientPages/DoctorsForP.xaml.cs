using Dentistry.Models;
using Dentistry.Services;
using Dentistry.ViewModels;
using Dentistry.ViewModels.PatientPagesViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dentistry.Views.PatientPages
{
    /// <summary>
    /// Логика взаимодействия для Doctors.xaml
    /// </summary>
    public partial class DoctorsForP : Page
    {
        public DoctorsForP()
        {
            DoctorsInPationViewModel admincontext = new DoctorsInPationViewModel();
            UnitOfWork unitOfWork = new UnitOfWork();
            DoctorsInPationViewModel.Doctors = new BindingList<Doctor>(unitOfWork.Doctors.GetAll().ToList());
            InitializeComponent();
            DataContext = admincontext;
            DoctorsList.ItemsSource = DoctorsInPationViewModel.Doctors;
        }
    }
}
