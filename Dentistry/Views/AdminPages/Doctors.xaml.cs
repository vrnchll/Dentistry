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
    /// Логика взаимодействия для Doctors.xaml
    /// </summary>
    public partial class Doctors : Page
    {
        public Doctors()
        {
            Admin_DoctorsViewModel admincontext = new Admin_DoctorsViewModel();
            UnitOfWork unitOfWork = new UnitOfWork();
            var doctors = unitOfWork.Doctors.GetAll().ToList();
            foreach (var doctor in doctors)
            {
                var user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.Id == doctor.Id);
                doctor.User = user;
            }
            Admin_DoctorsViewModel.Doctors = new BindingList<Doctor>(doctors);
            InitializeComponent();
            DataContext = admincontext;
            DoctorsList.ItemsSource = Admin_DoctorsViewModel.Doctors;
        }
        private RelayCommands _openSearch;
        public RelayCommands OpenSearch
        {
            get
            {
                return _openSearch ??
                    (_openSearch = new RelayCommands((selectedItem) =>
                    {
                        CloseSerachPanel.Visibility = Visibility.Visible;
                        OpenSerachPanel.Visibility = Visibility.Collapsed;
                    }));
            }
        }
        private RelayCommands _closeSearch;
        public RelayCommands CloseSearch
        {
            get
            {
                return _closeSearch ??
                    (_closeSearch = new RelayCommands((selectedItem) =>
                    {
                        OpenSerachPanel.Visibility = Visibility.Visible;
                        CloseSerachPanel.Visibility = Visibility.Collapsed;
                    }));
            }
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
