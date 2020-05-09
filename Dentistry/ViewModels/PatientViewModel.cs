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

namespace Dentistry.ViewModels
{
    public class PatientViewModel : INotifyPropertyChanged
    {
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

        private DateTime _DateOfBirth;
        public DateTime DateOfBirth
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
        private RelayCommands registrationCommand;
        public RelayCommands RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                (registrationCommand = new RelayCommands(obj =>
                {
                    if (Password == ConfirmPassword)
                    {
                        User user = new User() { UserName = Login, Password = Password, Email = Email, TypeUser = "Patient" };
                        Patient person = new Patient() {Id = user.Id, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, DateOfBirth = DateOfBirth.ToString("MM/dd/yyyy"), Gender = SelectedGender == 0 ? "Мужской" : "Женский", City = City, Street = Street, House = House, Flat = Flat, NumberOfPhone = NumberOfPhone };
                        user.PatientProfile = person;
                        Account.RegistrationPatient(user,person);
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают, повторите попытку");
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
