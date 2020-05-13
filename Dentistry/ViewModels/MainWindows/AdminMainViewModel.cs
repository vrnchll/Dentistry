using Dentistry.Context;
using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dentistry.ViewModels.MainWindows
{
    public class AdminMainViewModel : INotifyPropertyChanged
    {
        private Page Patients;
        private Page Doctors;
        private Page Receptions;
        private Page Compouns;
        private Page Servicess;
        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged("CurrentPage");

            }
        }
        public AdminMainViewModel()
        {
            Patients = new Patients();
            Doctors = new Doctors();
            Receptions = new Receptions();
            Compouns = new Compouns();
            Servicess = new ServicesAdmin();
            CurrentPage = Patients;
        }

        private RelayCommands _ShowPatients;
        public RelayCommands ShowPatients
        {
            get
            {
                return
                _ShowPatients ?? (
               _ShowPatients = new RelayCommands(obj =>
               {
                   CurrentPage = Patients;
               }));
            }
        }
        private RelayCommands _ShowDoctors;
        public RelayCommands ShowDoctors
        {
            get
            {
                return
                 _ShowDoctors ?? (
               _ShowDoctors = new RelayCommands(obj =>
               {
                   CurrentPage = Doctors;
               }));
            }
        }
        private RelayCommands _showReceptions;
        public RelayCommands ShowReceptions
        {
            get
            {
                return
                _showReceptions ?? (
               _showReceptions = new RelayCommands(obj =>
               {
                   CurrentPage = Receptions;
               }));
            }

        }
        private RelayCommands _ShowCompoun;
        public RelayCommands ShowCompoun
        {
            get
            {
                return
                _ShowCompoun ?? (
               _ShowCompoun = new RelayCommands(obj =>
               {
                   CurrentPage = Compouns;
               }));
            }

        }
        private RelayCommands _ShowServices;
        public RelayCommands ShowServices
        {
            get
            {
                return
                _ShowServices ?? (
               _ShowServices = new RelayCommands(obj =>
               {
                   UnitOfWork unitOfWork = new UnitOfWork();
                  
                   foreach (var service in unitOfWork.Services.Include())
                   {
                  
                       foreach (var person in service.Doctors.ToList())
                       {
                           service.Doctors.Add(person);
                           Admin_ServicesViewModel.Services.Add(service);

                       }
                  
                   }
                  
                   CurrentPage = Servicess;
               }));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}