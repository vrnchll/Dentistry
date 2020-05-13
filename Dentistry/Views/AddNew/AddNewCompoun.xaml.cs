using Dentistry.Services;
using Dentistry.ViewModels.AdminPagesViewModel;
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
    /// Логика взаимодействия для AddNewCompoun.xaml
    /// </summary>
    public partial class AddNewCompoun : Window
    {
        public AddNewCompoun()
        {
            DataContext = new AddNewCompounViewModel();
            UnitOfWork unitOfWork = new UnitOfWork();
            var patients = unitOfWork.Patients.GetAll().ToList();
            var doctors = unitOfWork.Doctors.GetAll().ToList();
           
            List<string> patientsName = new List<string>();
           
            List<string> doctorsName = new List<string>();
            InitializeComponent();
            foreach (var i in doctors)
            {
                doctorsName.Add(i.LastName);
            }
            foreach (var i in patients)
            {
                patientsName.Add(i.LastName);
            }
           
            docList.ItemsSource = doctorsName;
            patList.ItemsSource = patientsName;
            
        }
    }
}
