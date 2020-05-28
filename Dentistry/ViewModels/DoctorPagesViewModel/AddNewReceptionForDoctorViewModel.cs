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

namespace Dentistry.ViewModels.DoctorPagesViewModel
{
    public class AddNewReceptionForDoctorViewModel:INotifyPropertyChanged
    {
       
        public static List<string> LastNamePatients = new List<string>();
        public static List<string> ServicesNames = new List<string>();


        public Reception CurrentReception;
        private DateTime _Date;
        public DateTime Date
        {
            get
            {
                if (_Date == DateTime.MinValue)
                    return DateTime.Today;

                return _Date;
            }
            set
            {


                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        private string _Time;
        public string TimeOfBeggining
        {
            get
            {
                if (_Time == null) return "9:00";


                return _Time;
            }
            set
            {
                _Time = value;
                OnPropertyChanged("Time");
            }
        }
        private string _TimeE;
        public string TimeOfEnding
        {
            get
            {
                if (_TimeE == null) return "10:00";


                return _TimeE;
            }
            set
            {
                _TimeE = value;
                OnPropertyChanged("Time");
            }
        }
        public string _LastNamePatient;
        public string LastNamePatient
        {
            get => _LastNamePatient; set
            {
                _LastNamePatient = value;
                OnPropertyChanged("LastNamePatient");
            }
        }
        
        public string _Services;
        public string Services
        {
            get => _Services; set
            {
                _Services = value;
                OnPropertyChanged("Services");
            }
        }


        private string _SelectedService;
        public string SelectedService
        {
            get => _SelectedService;
            set
            {
                _SelectedService = value;
                OnPropertyChanged("Selected Type");
            }
        }
        private string _SelectedPatient;
        public string SelectedPatient
        {
            get => _SelectedPatient;
            set
            {
                _SelectedPatient = value;
                OnPropertyChanged("Selected Type");
            }
        }

        private RelayCommands _add;
        public RelayCommands Add
        {
            get
            {
                return
                _add ?? (
               _add = new RelayCommands(obj =>
               {
               if (SelectedPatient != null && SelectedService != null)
               {
                       if (DateTime.ParseExact(TimeOfBeggining, "H:mm", null) < DateTime.ParseExact(TimeOfEnding, "H:mm", null))
                       {
                           UnitOfWork unitOfWork = new UnitOfWork();
                   var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == Account.GetInstance().Id);
                   var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.LastName == LastNamePatient);
                   var service = unitOfWork.Services.GetAll().FirstOrDefault(x => x.Name == Services);

    
                       Reception reception = new Reception()
                       {
                           DateOfReception = DateTime.Today.ToString("dd.MM.yyyy"),
                           TimeOfBeginReception = TimeOfBeggining,
                           TimeOfEndReception = TimeOfEnding,
                           ServiceId = service.Id,
                           DoctorId = doctor.Id,
                           PatientId = patient.Id

                       };
                       var resultsReception = new List<ValidationResult>();
                       var contextReception = new ValidationContext(reception);
                       var resultsService = new List<ValidationResult>();
                       var contextService = new ValidationContext(service);
                       var resultsDoctor = new List<ValidationResult>();
                       var contextDoctor = new ValidationContext(doctor);
                       var resultsPatient = new List<ValidationResult>();
                       var contextPatientr = new ValidationContext(patient);
                       if (!Validator.TryValidateObject(service, contextService, resultsService, true) || !Validator.TryValidateObject(doctor, contextDoctor, resultsDoctor, true) || !Validator.TryValidateObject(reception, contextReception, resultsReception, true) || !Validator.TryValidateObject(patient, contextPatientr, resultsPatient, true))
                       {
                           foreach (var error in resultsDoctor)
                           {
                               MessageBox.Show(error.ErrorMessage);
                           }
                           foreach (var error in resultsService)
                           {
                               MessageBox.Show(error.ErrorMessage);
                           }
                           foreach (var error in resultsReception)
                           {
                               MessageBox.Show(error.ErrorMessage);
                           }
                           foreach (var error in resultsPatient)
                           {
                               MessageBox.Show(error.ErrorMessage);
                           }
                       }
                       else
                       {
                           ReceptionsForDViewModel.Receptions.Add(reception);
                           unitOfWork.Receptions.Create(reception);
                           unitOfWork.Save();
                           MessageBox.Show("Посещение добавлено!");
                           if (App.addNewReception != null) App.addNewReception.Visibility = Visibility.Hidden;

                       }

                       }
                       else
                       {
                           MessageBox.Show("Некорректное время");
                       }
                   }

                   else
                   {
                       MessageBox.Show("Вы не выбрали элемент(ы)!");
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

