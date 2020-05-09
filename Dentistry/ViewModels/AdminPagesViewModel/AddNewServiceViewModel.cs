using Dentistry.Models;
using Dentistry.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.ViewModels.AdminPagesViewModel
{
   public class AddNewServiceViewModel:INotifyPropertyChanged
    {
        private string _Name;
        public string Name {
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
        private string _SelectedItem;
        public string SelectedItem
        {
            get => _SelectedItem; 
            set
            {
                _SelectedItem = value;
                OnPropertyChanged("Selected Type");
            }
        }
        private RelayCommands _add;
        public RelayCommands add
        {
            get
            {
                return
                _add ?? (
               _add = new RelayCommands(obj =>
               {
                   UnitOfWork unitOfWork = new UnitOfWork();
                   var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.LastName.Contains(SelectedItem));
                   Service service = new Service()
                   {
                       Cost = Cost,
                       Name = Name,
                       
                   };
                   service.Doctors.Add(doctor);
                   unitOfWork.Services.Create(service);
                   unitOfWork.Save();
                   Admin_ServicesViewModel.Services.Add(service);
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
