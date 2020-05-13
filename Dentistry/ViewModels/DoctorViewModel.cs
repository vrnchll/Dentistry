using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels
{
    public class DoctorViewModel : INotifyPropertyChanged
    {
        private string _FirstName;
        public DateTime _ReportPlanningDate = DateTime.Today;
        public string FirstName { get => _FirstName; set
            {
                _FirstName = value;
                OnPropertyChanged("FirstName");
            } }

        private string _LastName;
        public string LastName { get => _LastName; set
            {
                _LastName = value;
                OnPropertyChanged("LastName");
            } }
        private string _MiddleName;
        public string MiddleName { get => _MiddleName; set
            {
                _MiddleName = value;
                OnPropertyChanged("MiddleName");
            } }

        private DateTime _DateOfBirth;
        public DateTime DateOfBirth { get => _DateOfBirth; set
            {
                if (_DateOfBirth == DateTime.MinValue) _DateOfBirth= DateTime.Today;
                else _DateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            } }

        private bool[] _Gender = new bool[] { true, false };
        public bool[] Gender { get=>_Gender; }
        public int SelectedGender { get => Array.IndexOf(_Gender, true); }

        private string _Position;
        public string Position { get=>_Position; set
            {
                _Position = value;
                OnPropertyChanged("Position");
            } }
        private string _Experience;
        public string Experience { get=>_Experience; set
            {
                _Experience = value;
                OnPropertyChanged("Experience");
            }
        }

        private string _NumberOfPhone;
        public string NumberOfPhone { get=>_NumberOfPhone; set
            {
                _NumberOfPhone = value;
                OnPropertyChanged("NumberOfPhone");
            }
        }

        private string _Cabinet;
        public string Cabinet { get=>_Cabinet; set
            {
                _Cabinet = value;
                OnPropertyChanged("Cabinet");
            }
        }

        private string _Login;
        public string Login { get=>_Login; set
            {
                _Login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _Password;
        public string Password { get=>_Password; set
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
        public string Email { get=>_Email; set
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
                        
                        User user = new User() { UserName = Login, Password = Password, Email = Email, TypeUser = "Doctor" };
                        Doctor person = new Doctor() {Id=user.Id, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, DateOfBirth = DateOfBirth.ToString(), Gender = SelectedGender == 0 ? "Mужской" : "Женский",Experience=Experience,Position=Position,Cabinet=Cabinet, NumberOfPhone = NumberOfPhone };
                        user.DoctorProfile = person;
                        Account.RegistrationDoctor(user, person);
                        if (App.AddNewDoctor != null)
                        { App.AddNewDoctor.Visibility = Visibility.Hidden; }
                        
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
