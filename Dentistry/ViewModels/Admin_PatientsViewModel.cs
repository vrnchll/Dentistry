using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels
{
    class Admin_PatientsViewModel : INotifyPropertyChanged

    {
        public static BindingList<Patient> Patients;

        static Admin_PatientsViewModel()
        {
            Patients = new BindingList<Patient>();
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

        private string _gender;

        public string Gender
        {
            get => _gender; set
            {
                _gender = value;
                OnPropertyChanged("City");
            }
        }
     

        private string _City;
        public string City
        {
            get => _City; set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }

        private string _Street;
        public string Street
        {
            get => _Street; set
            {
                _Street = value;
                OnPropertyChanged("Street");
            }
        }
        private string _House;
        public string House
        {
            get => _House; set
            {
                _House = value;
                OnPropertyChanged("House");
            }
        }
        private string _Flat;
        public string Flat
        {
            get => _Flat; set
            {
                _Flat = value;
                OnPropertyChanged("Flat");
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
        private string _Login;
        public string Login
        {
            get => _Login; set
            {
                _Login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _Password;
        public string Password
        {
            get => _Password; set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }
        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get => _ConfirmPassword; set
            {
                _ConfirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private string _Email;
        public string Email
        {
            get => _Email; set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        private RelayCommands _Add;
        public RelayCommands Add
        {
            get
            {
                return
                _Add ?? (
               _Add = new RelayCommands(obj =>
               {
                   App.addNewPatient = new AddNewPatient();
                   App.addNewPatient.Show();
                   

               }));
            }

        }

        //Search

        private string _FirstNames;
        public string FirstNames
        {
            get
            {
                return _FirstNames;
            }
            set
            {
                _FirstNames = value;
                OnPropertyChanged("FirstNames");
            }
        }
        private string _LastNames;
        public string LastNames
        {
            get
            {
                return _LastNames;
            }
            set
            {
                _LastNames = value;
                OnPropertyChanged("LastNames");
            }
        }
        private string _Number;
        public string Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
                OnPropertyChanged("Number");
            }
        }
        private string _DateOfBirthd;
        public string DateOfBirthd
        {
            get
            {
                return _DateOfBirthd;
            }
            set
            {
                _DateOfBirthd = value;
                OnPropertyChanged("DateOfBirthd");
            }
        }


        private RelayCommands _SearchCommand;
        public RelayCommands SearchCommand 
        {
            get
            {
                return
                _SearchCommand ?? (
               _SearchCommand = new RelayCommands(obj =>
               {
                   Search.SearchPatients(FirstNames==""?null:FirstNames,LastNames==""?null:LastNames,NumberOfPhone==""?null:NumberOfPhone,DateOfBirthd == ""?null:DateOfBirth);
               }));
                
            }

        }
        private RelayCommands _Clear;
        public RelayCommands Clear
        {
            get
            {
                return
                _Clear ?? (
               _Clear = new RelayCommands(obj =>
               {
                   UnitOfWork unitOfWork = new UnitOfWork();
                   var paients = unitOfWork.Patients.GetAll().ToList();
                   Admin_PatientsViewModel.Patients.Clear();
                   foreach (var pat in paients)
                   {
                       Patients.Add(pat);
                   }
               }));
            }

        }
        //------------------------------


        private Patient selectedPatient;
        public Patient SelectedPatient
        {
            get
            {
                return selectedPatient;
            }
            set
            {
                selectedPatient = value;
                OnPropertyChanged("SelectedPatient");
            }
        }
        
        private RelayCommands _removeCommand;
        public RelayCommands RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommands((selectedItem) =>
                    {
                        UnitOfWork unitOfWork = new UnitOfWork();
                        MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (selectedPatient == null || result == MessageBoxResult.No) return;

                        Patient patient = selectedPatient as Patient;
                        Patients.Remove(patient);
                        unitOfWork.Patients.Delete(patient.Id);
                        var compouns = unitOfWork.Compouns.GetAll();
                        foreach (var compoun in compouns)
                        {
                            if (compoun.PatientId == patient.Id)
                                unitOfWork.Compouns.Delete(compoun.Id);
                        }
                        unitOfWork.Users.Delete(patient.Id);
                        unitOfWork.Save();
                        OnPropertyChanged("Remove");
                    }));
            }
        }
        private RelayCommands _EditCommand;
        public RelayCommands EditCommand
        {
            get
            {
                return _EditCommand ??
                    (_EditCommand = new RelayCommands((selectedItem) =>
                    {
                        if (SelectedPatient != null)
                        {
                            AddNewPatient addNewPatient = new AddNewPatient(SelectedPatient);
                            addNewPatient.Show(); 
                            OnPropertyChanged("Edit");
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
