using Dentistry.Models;
using Dentistry.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels.AdminPagesViewModel
{
   public class AddNewServiceViewModel:INotifyPropertyChanged
    {
        public readonly Service _service;
        public AddNewServiceViewModel(Service service = null)
        {
            if (service != null)
            {
                Name = service.Name;
                OldName = service.Name;
                Cost = service.Cost;
            }
            _service = service;
        }
        private string _OldName;
      
        public string OldName
        {
            get => _OldName; set
            {
                _OldName = value;
                OnPropertyChanged("Name");
            }
        }
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
                   if (SelectedItem != null)
                   {
                       UnitOfWork unitOfWork = new UnitOfWork();
                       var doctor = unitOfWork.Doctors.GetAll().ToList().FirstOrDefault(x => x.LastName.Contains(SelectedItem));
                       var services = unitOfWork.Services.GetAll().ToList().FirstOrDefault(x => x.Name == OldName);
                       
                       if (services != null)
                       {
                           Service service = new Service() { Name = Name, Cost = Cost, };
                           service.Doctors.Add(doctor);
                           doctor.Services.Add(service);
                           unitOfWork.Doctors.Update(doctor);
                           unitOfWork.Save();
                           Account.EditInformationService(service, _service);
                           if (App.addNewService != null) App.addNewService.Visibility = Visibility.Hidden;
                       }
                       else
                       {
                           Service service = new Service()
                           {
                               Cost = Cost,
                               Name = Name,

                           };
                           var resultsService = new List<ValidationResult>();
                           var contextService = new ValidationContext(service);
                           var resultsDoctor = new List<ValidationResult>();
                           var contextDoctor = new ValidationContext(doctor);
                           if (!Validator.TryValidateObject(service, contextService, resultsService, true) || !Validator.TryValidateObject(doctor, contextDoctor, resultsDoctor, true))
                           {
                               foreach (var error in resultsDoctor)
                               {
                                   MessageBox.Show(error.ErrorMessage);
                               }
                               foreach (var error in resultsService)
                               {
                                   MessageBox.Show(error.ErrorMessage);
                               }
                           }
                           else
                           {

                               service.Doctors.Add(doctor);
                               unitOfWork.Services.Create(service);
                               unitOfWork.Save();
                               Admin_ServicesViewModel.Services.Add(service);


                               if (App.addNewService != null) App.addNewService.Visibility = Visibility.Hidden;
                           }
                       }
                   }
                   else
                   {
                       MessageBox.Show("Вы не выбрали доктора!");
                   }
                   
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
