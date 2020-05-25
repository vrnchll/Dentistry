using Dentistry.Models;
using Dentistry.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels.AdminPagesViewModel
{
    public class AddNewReceptionViewModel : INotifyPropertyChanged
    {
       


        public static List<string> LastNamePatients = new List<string>();
        public static List<string> LastNameDoctors = new List<string>();
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
            get => _Time; set
            {
                _Time = value;
                OnPropertyChanged("Time");
            }
        }
        private string _TimeE;
        public string TimeOfEnding
        {
            get => _TimeE; set
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
        public string _LastNameDoctor;
        public string LastNameDoctor
        {
            get => _LastNameDoctor; set
            {
                _LastNameDoctor = value;
                OnPropertyChanged("LastNameDoctor");
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

        public readonly Reception _reception;

        public AddNewReceptionViewModel(Reception reception = null)
        {
            LastNamePatients = new List<string>();
            LastNameDoctors = new List<string>();
            if (reception != null)
            {
                CurrentReception = reception;
                Date = DateTime.Parse(reception.DateOfReception);
                TimeOfBeggining = reception.TimeOfBeginReception;
                TimeOfEnding = reception.TimeOfEndReception;
                Services = reception.Service.Name;
                LastNameDoctor = reception.Doctor.LastName;
                LastNamePatient = reception.Patient.LastName;
            }
            _reception = reception;
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
                   UnitOfWork unitOfWork = new UnitOfWork();
                   var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.LastName == LastNameDoctor);
                   var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.LastName == LastNamePatient);
                   var service = unitOfWork.Services.GetAll().FirstOrDefault(x => x.Name == Services);

                   if (CurrentReception != null)
                   {
                       Reception reception = new Reception()
                       {
                           DateOfReception = Date.ToString("dd.MM.yyyy"),
                           TimeOfBeginReception = TimeOfBeggining,
                           TimeOfEndReception = TimeOfEnding,
                           ServiceId = service.Id,
                           DoctorId = doctor.Id,
                           PatientId = patient.Id

                       };
                       Account.EditInformationReception(reception, _reception, doctor, patient, service);
                       if (App.addNewReception != null) App.addNewReception.Visibility = Visibility.Hidden;
                   }
                   else
                   {

                       Reception reception = new Reception()
                       {
                           DateOfReception = Date.ToString("dd.MM.yyyy"),
                           TimeOfBeginReception = TimeOfBeggining,
                           TimeOfEndReception = TimeOfEnding,
                           ServiceId = service.Id,
                           DoctorId = doctor.Id,
                           PatientId = patient.Id

                       };
                       unitOfWork.Receptions.Create(reception);
                       unitOfWork.Save();
                       Admin_ReceptionsViewModel.Receptions.Add(reception);
                       if (App.addNewReception != null) App.addNewReception.Visibility = Visibility.Hidden;



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
