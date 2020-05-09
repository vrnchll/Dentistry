using Dentistry.Models;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.ViewModels
{
    class Admin_ServicesViewModel : INotifyPropertyChanged
    {
        public static BindingList<Service> Services;
        public static BindingList<string> DoctorsName;
        public Admin_ServicesViewModel()
        {
            Services = new BindingList<Service>();
            DoctorsName = new BindingList<string>();
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
                   AddNewService newService = new AddNewService();
                   newService.Show();
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
