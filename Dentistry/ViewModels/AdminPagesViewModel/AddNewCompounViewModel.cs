using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
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
    public class AddNewCompounViewModel : INotifyPropertyChanged
    {
        public static List<string> LastNamePatients = new List<string>();
        public static List<string> LastNameDoctors = new List<string>();

        private string _ChangeContentLabel = "Добавление нового талона";
    
        public string ChangeContentLabel
        {
            get => _ChangeContentLabel; set
            {
                _ChangeContentLabel = value;
                OnPropertyChanged("ChangeContentLabel");
            }
        }
        string regNames = @"^[a-zA-Zа-яА-Я]{2,25}$";
        public Compoun CurrentCompoun; 
        private DateTime _Date;
        public DateTime Date
        {
            get {
                if (_Date == DateTime.MinValue)
                    return DateTime.Today;

                return _Date; }  
            set
            {
           
    
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        private string _Time;
        public string Time
        {
            get {
                if (_Time == null) return "9:00";
                
                
                return _Time; }
            
            set
            {
                _Time = value;
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
        public string _Status;
        public string Status
        {
            get => _Status; set
            {
                _Status = value;
                OnPropertyChanged("Status");
            }
        }

        public readonly Compoun _compoun;
        public AddNewCompounViewModel(Compoun compoun = null)
        {
            LastNamePatients = new List<string>();
            LastNameDoctors = new List<string>();
            if (compoun != null)
            {
                CurrentCompoun = compoun;
                Date = DateTime.Parse(compoun.DateOfReception);
                Time = compoun.TimeOfReception;
                Status = compoun.Status;
                LastNameDoctor = compoun.Doctor.LastName;
                LastNamePatient = compoun.Patient.LastName;
                SelectedPatient = LastNamePatient;
                SelectedDoctor = LastNameDoctor;
                ChangeContentLabel = "Редактирование талона";
            }
            _compoun = compoun;
        }
        private bool _ordered;
        public bool Order
        {
            get { return _ordered; }
            set
            {
                _ordered = value;
                OnPropertyChanged("Order");
            }
        }
        private RelayCommands _Exit;
        public RelayCommands Exit
        {
            get
            {
                return
                _Exit ?? (
               _Exit = new RelayCommands(obj =>
               {
                   if (App.addNewCompoun != null)
                   {
                       App.addNewCompoun.Close();
                   }
               }));
            }

        }
        private string _SelectedDoctor;
        public string SelectedDoctor
        {
            get => _SelectedDoctor;
            set
            {
                _SelectedDoctor = value;
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
              
                   UnitOfWork unitOfWork = new UnitOfWork();
                   var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.LastName == LastNameDoctor);
                   var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.LastName == LastNamePatient);
                   var compouns = unitOfWork.Compouns.GetAll().ToList().FindAll(x => x.IsOrder == false);

                   if (CurrentCompoun != null)
                   {
                       if (SelectedDoctor != null && SelectedPatient != null)
                       {
                           Compoun compoun = new Compoun()
                           {
                               Id = CurrentCompoun.Id,
                               DateOfReception = Date.ToString("dd.MM.yyyy"),
                               Status = Status,
                               IsOrder = true,
                               TimeOfReception = Time,
                               DoctorId = doctor.Id,
                               PatientId = patient.Id

                           };
                           var resultsDoctor = new List<ValidationResult>();
                           var contextDoctor = new ValidationContext(doctor);
                           var resultsPatient = new List<ValidationResult>();
                           var contextPatientr = new ValidationContext(patient);
                           if (!Validator.TryValidateObject(doctor, contextDoctor, resultsDoctor, true) || !Validator.TryValidateObject(patient, contextPatientr, resultsPatient, true))
                           {
                               foreach (var error in resultsDoctor)
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
                               Account.EditInformationCompoun(compoun, _compoun, doctor, patient);
                               if (App.addNewCompoun != null) App.addNewCompoun.Visibility = Visibility.Hidden;
                           }

                       }
                       else
                       {
                           MessageBox.Show("Вы не выбрали элемент(ы)!");
                       }
                       
                   }
                   else
                   {
                       if (SelectedDoctor != null && SelectedPatient != null)
                       {
                           Compoun compoun = new Compoun()
                           {
                               DateOfReception = Date.ToString("dd.MM.yyyy"),
                               Status = Status,
                               IsOrder = true,
                               TimeOfReception = Time,
                               DoctorId = doctor.Id,
                               PatientId = patient.Id

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

                               OrderManager.OrderCompounAdmin(doctor, compoun, patient);
                           }
                       }
                       else
                       {
                           MessageBox.Show("Вы не выбрали элемент(ы)!");
                       }
                       


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
