using Dentistry.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dentistry.Views.DoctorPages
{
    /// <summary>
    /// Логика взаимодействия для AddNewReceptionForDoctor.xaml
    /// </summary>
    public partial class AddNewReceptionForDoctor : Page
    {
        public AddNewReceptionForDoctor()
        {
            DataContext = new AddNewReceptionForDoctorViewModel();
            UnitOfWork unitOfWork = new UnitOfWork();
            var patients = unitOfWork.Patients.GetAll().ToList();
            var services = unitOfWork.Services.GetAll().ToList();
            List<string> patientsName = new List<string>();
            List<string> servicesName = new List<string>();
            InitializeComponent();
            foreach (var i in patients)
            {
                patientsName.Add(i.LastName);
            }
            foreach (var i in services)
            {
                servicesName.Add(i.Name);
            }
            patList.ItemsSource = patientsName;
            serList.ItemsSource = servicesName;


        }
    }
}
