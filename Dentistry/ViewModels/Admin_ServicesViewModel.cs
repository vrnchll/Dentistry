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
using System.Windows;

namespace Dentistry.ViewModels
{
    class Admin_ServicesViewModel : INotifyPropertyChanged
    {
        public static BindingList<Service> Services;
        public static BindingList<Doctor> DoctorsName;
        public Admin_ServicesViewModel()
        {
            Services = new BindingList<Service>();

        }
        private string _Name;
        public string Name
        {
            get => _Name; set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _Cost;
        public string Cost
        {
            get => _Cost; set
            {
                _Cost = value;
                OnPropertyChanged("Cost");
            }
        }


        private RelayCommands _Add;
        public RelayCommands Add
        {
            get
            {
                return
                _Add ?? (
               _Add = new RelayCommands(obj =>
               {
                   App.addNewService = new AddNewService();
                   App.addNewService.Show();
               }));
            }

        }
        private Service selectedService;
        public Service SelectedService
        {
            get
            {
                return selectedService;
            }
            set
            {
                selectedService = value;
                OnPropertyChanged("SelectedService");
            }
        }

        private RelayCommands _removeCommand;
        public RelayCommands RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommands((selectedItem) =>
                    {
                        if (SelectedService != null)
                        {

                            UnitOfWork unitOfWork = new UnitOfWork();
                            MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (selectedService == null || result == MessageBoxResult.No) return;

                            Service service = selectedService as Service;
                            Services.Remove(service);
                            unitOfWork.Services.Delete(service.Id);
                            //unitOfWork.Doctors.Delete(service.Id);
                            unitOfWork.Save();
                            OnPropertyChanged("Remove");
                        }
                        else
                        {
                            MessageBox.Show("Вы не выбрали элемент!");
                        }
                    }));
            }
        }
        private RelayCommands _EditCommand;
        public RelayCommands EditCommand
        {
            get
            {
                return _EditCommand ??
                    (_EditCommand = new RelayCommands((selectedItem) =>
                    {
                        if (SelectedService != null)
                        {

                            App.addNewService = new AddNewService(SelectedService);
                            App.addNewService.Show();
                            OnPropertyChanged("Edit");
                        }
                        else
                        {
                            MessageBox.Show("Вы не выбрали элемент!");
                        }
                    }));
            }
        }
        private string _SearchS;
        public string SearchS
        {
            get
            {
                return _SearchS;
            }
            set
            {
                _SearchS = value;
                OnPropertyChanged("SelectedService");
            }
        }
        private RelayCommands _SearchCommand;
        public RelayCommands SearchCommand
        {
            get
            {
                return
                _SearchCommand ?? (
               _SearchCommand = new RelayCommands(obj =>
               {
                   Search.SearchServices(SearchS == "" ? null : SearchS);
               }));
            }

        }
        private RelayCommands _Clear;
        public RelayCommands Clear
        {
            get
            {
                return
                _Clear ?? (
               _Clear = new RelayCommands(obj =>
               {
                   UnitOfWork unitOfWork = new UnitOfWork();
               
                   Services.Clear();
                   foreach (var service in unitOfWork.Services.Include())
                   {
                       foreach (var person in service.Doctors.ToList())
                       {

                           service.Doctors.Add(person);
                           

                       }
                       Services.Add(service);
                   }
               }));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged; 
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
