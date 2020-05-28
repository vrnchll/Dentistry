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
            get {
                if (_Date == DateTime.MinValue)
                    return DateTime.Today;

                return _Date;
            } set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        private string _Time;
        public string Time
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
       
        private RelayCommands _add;
        public RelayCommands Add
        {
            get
            {
                return
                _add ?? (
               _add = new RelayCommands(obj =>
               {
                   if ( SelectedDoc != null)
                   {

                       UnitOfWork unitOfWork = new UnitOfWork();

                       var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.LastName == LastNameDoctor);
            

                       Compoun compoun = new Compoun()
                       {
                           DateOfReception = Date.ToString("dd.MM.yyyy"),
                           TimeOfReception = Time,
                           Status = "Не выполнено",
                           DoctorId = doctor.Id,
                           PatientId = Account.GetInstance().Id

                       };
                       var resultsCompoun = new List<ValidationResult>();
                       var contextCompoun = new ValidationContext(compoun);
                   
                       if (!Validator.TryValidateObject(compoun, contextCompoun, resultsCompoun, true))
                       {
                          
                           foreach (var error in resultsCompoun)
                           {
                               MessageBox.Show(error.ErrorMessage);
                           }
                       }
                       else
                       {

                           OrderManager.OrderCompoun(doctor,compoun);
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
