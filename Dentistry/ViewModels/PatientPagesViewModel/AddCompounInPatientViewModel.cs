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
        public static List<string> Services = new List<string>();
        private string _Date;
        public string Date
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
            get => _Date; set
            {
                _Date = value;
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
                   Compoun compoun = new Compoun()
                   {
                       DateOfReception = Date,
                       TimeOfReception = Time,
                       DoctorId = doctor.Id,
                       PatientId = patient.Id

                   };

                   unitOfWork.Compouns.Create(compoun);
                   unitOfWork.Save();
                   MessageBox.Show("Ваш талон заказан!");
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
