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
                   App.AddNewService = new AddNewService();
                   App.AddNewService.Show();
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
                        UnitOfWork unitOfWork = new UnitOfWork();
                        MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (selectedService == null || result == MessageBoxResult.No) return;

                        Service service = selectedService as Service;
                        Services.Remove(service);
                        unitOfWork.Services.Delete(service.Id);
                        //unitOfWork.Doctors.Delete(service.Id);
                        unitOfWork.Save();
                        OnPropertyChanged("Remove");
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
