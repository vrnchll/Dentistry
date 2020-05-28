using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
using Dentistry.Views.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        string regNames = @"^[a-zA-Zа-яА-Я]{2,25}$";
        string regDOfBirs = @"([0-2]\d|3[01])\.(0\d|1[012])\.(\d{4})";
        string regInt = @"^[0-9]{1,3}$";
        private string _FirstName;
        public string FirstName
        {
            get => _FirstName; set
            {
                if (Regex.IsMatch(value, regNames, RegexOptions.IgnoreCase))
                    _FirstName = value;
                else
                    MessageBox.Show("Недопустимые символы в имени");
                OnPropertyChanged("FirstName");
            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName; set
            {
                if (Regex.IsMatch(value, regNames, RegexOptions.IgnoreCase))
                    _LastName = value;
                else
                    MessageBox.Show("Недопустимые символы в фамилии");
                OnPropertyChanged("LastName");
            }
        }
        private string _MiddleName;
        public string MiddleName
        {
            get => _MiddleName; set
            {
                if (Regex.IsMatch(value, regNames, RegexOptions.IgnoreCase))
                    _MiddleName = value;
                 else
                    MessageBox.Show("Недопустимые символы в отчестве");
                OnPropertyChanged("MiddleName");
            }
        }

        private string _DateOfBirth;
        public string DateOfBirth
        {
            get => _DateOfBirth; set
            {
                if (Regex.IsMatch(value, regDOfBirs, RegexOptions.IgnoreCase))
                    _DateOfBirth = value;
                else
                    MessageBox.Show("Неверный формат даты, введите в формате dd.MM.yyyy");
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
                if (Regex.IsMatch(value, regNames, RegexOptions.IgnoreCase))
                    _Street = value;
                else
                    MessageBox.Show("Недопустимые символы в улице");
                OnPropertyChanged("Street");
            }
        }
        private string _House;
        public string House
        {
            get => _House; set
            {
                if (Regex.IsMatch(value, regInt, RegexOptions.IgnoreCase))
                    _House = value;
                else
                    MessageBox.Show("Дом должен содержать только цифры");
                OnPropertyChanged("House");
            }
        }
        private string _Flat;
        public string Flat
        {
            get => _Flat; set
            {
                if (Regex.IsMatch(value, regInt, RegexOptions.IgnoreCase))
                    _Flat = value;
                else
                    MessageBox.Show("Дом должен содержать только цифры");
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

        public string Password { private get; set; }
        public string ConfirmPassword { private get; set; }

        private string _Email;
        public string Email
        {
            get => _Email; set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        public Patient CurrentPatient;
        private string _ChangeContentLabel = "Добавление нового пациента";

        public string ChangeContentLabel
        {
            get => _ChangeContentLabel; set
            {
                _ChangeContentLabel = value;
                OnPropertyChanged("ChangeContentLabel");
            }
        }
        public readonly Patient _patient;
        public PatientViewModel(Patient patient=null)
        {
            if (patient != null) {
            CurrentPatient = patient;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            MiddleName = patient.MiddleName;
            DateOfBirth = patient.DateOfBirth;
            City = patient.City;
            Street = patient.Street;
            House = patient.House;
            Flat = patient.Flat;
            Email = patient.User.Email;
            NumberOfPhone = patient.NumberOfPhone;
            Login = patient.User.UserName;
            ChangeContentLabel = "Редактирование пациента";

            }
            _patient = patient;
        }
        private RelayCommands _ReturnBack;
        public RelayCommands ReturnBack
        {
            get
            {
                return
                _ReturnBack ?? (
               _ReturnBack = new RelayCommands(obj =>
               {

                   App.Current.MainWindow.Visibility = Visibility.Visible;
                   App.RegistrationWindow.Visibility = Visibility.Hidden;


               }));
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
                    UnitOfWork unitOfWork = new UnitOfWork();
                    var users = unitOfWork.Users.GetAll().FirstOrDefault(x => x.UserName == Login);
                    if (CurrentPatient != null)
                    {
                       
                            User user = new User() { Id = users.Id, UserName = Login, Password = Password==null?users.Password:Password, Email = Email, TypeUser = "Patient" };
                            Patient person = new Patient() { Id = users.Id, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, DateOfBirth = DateOfBirth, Gender = SelectedGender == 0 ? "Мужской" : "Женский", City = City, Street = Street, House = House, Flat = Flat, NumberOfPhone = NumberOfPhone };
                            user.PatientProfile = person;
                            Account.EditInformationPatient(person, user, _patient, users.Password);
                           
                        
                    }
                    else
                    {
                        if (Password == ConfirmPassword)
                        {
                           
                                User user = new User() { UserName = Login, Password = Password, Email = Email, TypeUser = "Patient" };
                                Patient person = new Patient() { Id = user.Id, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, DateOfBirth = DateOfBirth, Gender = SelectedGender == 0 ? "Мужской" : "Женский", City = City, Street = Street, House = House, Flat = Flat, NumberOfPhone = NumberOfPhone };
                                user.PatientProfile = person;
                                Account.RegistrationPatient(user, person);
                               
                              
                            
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают, повторите попытку");
                        }
                    }
                    
                }));
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
                   if (App.addNewPatient != null)
                   {
                       App.addNewPatient.Close();
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
