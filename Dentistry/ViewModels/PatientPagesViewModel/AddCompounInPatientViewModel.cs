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
using System.Windows.Data;

namespace Dentistry.ViewModels.PatientPagesViewModel
{
    public class AddCompounInPatientViewModel : INotifyPropertyChanged
    {
        public static List<string> LastNamePatients = new List<string>();
        public static List<string> LastNameDoctors = new List<string>();
      
      
        private DateTime _Date;
        public DateTime Date
        {
            get => _Date; set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        private string _Time;
        public string Time
        {
            get => _Time; set
            {
                _Time = value;
                OnPropertyChanged("Time");
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
        public string _LastNamePatient;
        public string LastNamePatient
        {
            get => _LastNamePatient; set
            {
                _LastNamePatient = value;
                OnPropertyChanged("LastNamePatient");
            }
        }
        public string _Status;
        public string Status
        {
            get => _Status; set
            {
                _Status = value;
                OnPropertyChanged("Status");
            }
        }
        private string _SelectedDoc;
        public string SelectedDoc
        {
            get => _SelectedDoc;
            set
            {
                _SelectedDoc = value;
                OnPropertyChanged("Selected Type");
            }
        }
        private string _SelectedPat;
        public string SelectedPat
        {
            get => _SelectedPat;
            set
            {
                _SelectedPat = value;
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
                   if (SelectedPat != null && SelectedDoc != null)
                   {

                       UnitOfWork unitOfWork = new UnitOfWork();

                       var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.LastName == LastNameDoctor);
                       var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.LastName == LastNamePatient);

                       Compoun compoun = new Compoun()
                       {
                           DateOfReception = Date.ToString("dd MMMM yyyy"),
                           TimeOfReception = Time,
                           Status = Status,
                           DoctorId = doctor.Id,
                           PatientId = patient.Id

                       };

                       PatientProfileViewModel.Compouns.Add(compoun);

                       unitOfWork.Compouns.Create(compoun);
                       unitOfWork.Save();
                       MessageBox.Show("Ваш талон заказан!");
                   }
                   else
                   {
                       MessageBox.Show("Вы не выбрали элемент!");
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
