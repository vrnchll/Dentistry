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
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class ServicesForP : Page
    {
        public ServicesForP()
        {
            InitializeComponent();
            DataContext = new ServicesInPatientViewModel();
            ServicesList.ItemsSource = ServicesInPatientViewModel.Services;
            UnitOfWork unitOfWork = new UnitOfWork();

            foreach (var service in unitOfWork.Services.Include())
            {

                foreach (var person in service.Doctors.ToList())
                {
                    service.Doctors.Add(person);
                    ServicesInPatientViewModel.Services.Add(service);

                }

            }
        }
    }
    }
