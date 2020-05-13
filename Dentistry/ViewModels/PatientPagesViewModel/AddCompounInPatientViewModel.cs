using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
        public string _Service;
        public string Service
        {
            get => _Service; set
            {
                _Service = value;
                OnPropertyChanged("Service");
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
