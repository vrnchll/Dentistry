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
    public class AddNewCompounViewModel : INotifyPropertyChanged
    {
        public static List<string> LastNamePatients = new List<string>();
        public static List<string> LastNameDoctors = new List<string>();


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
            get => _Time; set
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
                   var comp = compouns.Find(x => x.IsOrder == false);
                   if (comp != null)
                   {
                       if (CurrentCompoun != null)
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
                           Account.EditInformationCompoun(compoun, _compoun, doctor, patient);
                           if (App.addNewCompoun != null) App.addNewCompoun.Visibility = Visibility.Hidden;
                       }
                       else
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
                           unitOfWork.Compouns.Create(compoun);
                           unitOfWork.Save();
                           Admin_CompounsViewModel.Compouns.Add(compoun);
                           if (App.addNewCompoun != null) App.addNewCompoun.Visibility = Visibility.Hidden;


                      
                       }
                       }
                   else
                   {
                       MessageBox.Show("Свободных талонов на эту дату больше нет!");
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
