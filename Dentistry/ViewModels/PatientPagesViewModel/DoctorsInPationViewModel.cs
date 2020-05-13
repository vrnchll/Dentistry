using Dentistry.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.ViewModels.PatientPagesViewModel
{
    public class DoctorsInPationViewModel : INotifyPropertyChanged
    {
        public static BindingList<Doctor> Doctors;
        static DoctorsInPationViewModel()
        {
            Doctors = new BindingList<Doctor>();
          
        }
        private string _FirstName;
        public string FirstName
        {
            get => _FirstName; set
            {
                _FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName; set
            {
                _LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private string _MiddleName;
        public string MiddleName
        {
            get => _MiddleName; set
            {
                _MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private string _DateOfBirth;
        public string DateOfBirth
        {
            get => _DateOfBirth; set
            {
                _DateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        private bool[] _Gender = new bool[] { true, false };
        public bool[] Gender { get => _Gender; }
        public int SelectedGender { get => Array.IndexOf(_Gender, true); }

        private string _Position;
        public string Position
        {
            get => _Position; set
            {
                _Position = value;
                OnPropertyChanged("Position");
            }
        }
        private string _Experience;
        public string Experience
        {
            get => _Experience; set
            {
                _Experience = value;
                OnPropertyChanged("Experience");
            }
        }

        private string _NumberOfPhone;
        public string NumberOfPhone
        {
            get => _NumberOfPhone; set
            {
                _NumberOfPhone = value;
                OnPropertyChanged("NumberOfPhone");
            }
        }

        private string _Cabinet;

     

        public string Cabinet
        {
            get => _Cabinet; set
            {
                _Cabinet = value;
                OnPropertyChanged("Cabinet");
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
