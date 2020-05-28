using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
using Dentistry.Views.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels
{
    public class DoctorViewModel : INotifyPropertyChanged
    {
        string regNames = @"^[a-zA-Zа-яА-Я]{2,25}$";
        string regDOfBirs = @"([0-2]\d|3[01])\.(0\d|1[012])\.(\d{4})";
        string regInt = @"^[0-9]{1,2}$";
        private string _FirstName;
        public DateTime _ReportPlanningDate = DateTime.Today;
        public string FirstName { get => _FirstName; set
            {
                if (Regex.IsMatch(value, regNames, RegexOptions.IgnoreCase))
                    _FirstName = value;
                else
                    MessageBox.Show("Недопустимые символы в имени");
                OnPropertyChanged("FirstName");
            } }

        private string _LastName;
        public string LastName { get => _LastName; set
            {
                if (Regex.IsMatch(value, regNames, RegexOptions.IgnoreCase))
                    _LastName = value;
                else
                    MessageBox.Show("Недопустимые символы в фамилии");
                OnPropertyChanged("LastName");
            } }
        private string _MiddleName;
        public string MiddleName { get => _MiddleName; set
            {
                if (Regex.IsMatch(value, regNames, RegexOptions.IgnoreCase))
                    _MiddleName = value;
                else
                    MessageBox.Show("Недопустимые символы в отчестве");
                OnPropertyChanged("MiddleName");
            } }

        private string _DateOfBirth;
        public string DateOfBirth { get => _DateOfBirth; set
            {
                if (Regex.IsMatch(value, regDOfBirs, RegexOptions.IgnoreCase))
                    _DateOfBirth = value;
                else
                    MessageBox.Show("Неверный формат даты, введите в формате dd.MM.yyyy");
                OnPropertyChanged("DateOfBirth");
            } }

        private bool[] _Gender = new bool[] { true, false };
        public bool[] Gender { get => _Gender; }
        public int SelectedGender { get => Array.IndexOf(_Gender, true); }

        private string _Position;
        public string Position { get => _Position; set
            {
                _Position = value;
                OnPropertyChanged("Position");
            } }
        private string _Experience;
        public string Experience { get => _Experience; set
            {
                if (Regex.IsMatch(value, regInt, RegexOptions.IgnoreCase))
                    _Experience = value;
                else
                    MessageBox.Show("Стаж работы должен содержать только цифры");
                OnPropertyChanged("Experience");
            }
        }

        private string _NumberOfPhone;
        public string NumberOfPhone { get => _NumberOfPhone; set
            {
                _NumberOfPhone = value;
                OnPropertyChanged("NumberOfPhone");
            }
        }

        private string _Cabinet;
        public string Cabinet { get => _Cabinet; set
            {
                _Cabinet = value;
                OnPropertyChanged("Cabinet");
            }
        }

        private string _Login;
        public string Login { get => _Login; set
            {
                _Login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password {private get; set; }
        public string ConfirmPassword { private get ; set; }
       
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
        private string _Email;
        public string Email { get => _Email; set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        private string _ChangeContentLabel = "Добавление нового врача";

        public string ChangeContentLabel
        {
            get => _ChangeContentLabel; set
            {
                _ChangeContentLabel = value;
                OnPropertyChanged("ChangeContentLabel");
            }
        }
        public readonly Doctor _doctor;
        public DoctorViewModel(Doctor doctor = null)
        {
            if (doctor != null)
            {
                FirstName = doctor.FirstName;
                LastName = doctor.LastName;
                MiddleName = doctor.MiddleName;
                DateOfBirth = doctor.DateOfBirth;
                Position = doctor.Position;
                Experience = doctor.Experience;
                Cabinet = doctor.Cabinet;
                Email = doctor.User.Email;
                NumberOfPhone = doctor.NumberOfPhone;
                Login = doctor.User.UserName;
                ChangeContentLabel = "Редактирование врача";

            }
            _doctor = doctor;
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
                    if (users != null)
                    {

                        User user = new User() {Id=users.Id, UserName = Login, Password = Password == null ? users.Password : Password, Email = Email, TypeUser = "Doctor" };
                        Doctor person = new Doctor() { Id = user.Id, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, DateOfBirth = DateOfBirth, Gender = SelectedGender == 0 ? "Mужской" : "Женский", Experience = Experience, Position = Position, Cabinet = Cabinet, NumberOfPhone = NumberOfPhone };
                        user.DoctorProfile = person;
                        Account.EditInformationDoctor(person, user, _doctor, users.Password);
                        if (App.addNewDoctor != null) App.addNewDoctor.Visibility = Visibility.Hidden;

                    }
                    else
                    {
                        if (Password == ConfirmPassword)
                        {

                            User user = new User() { UserName = Login, Password = Password, Email = Email, TypeUser = "Doctor" };
                            Doctor person = new Doctor() { Id = user.Id, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, DateOfBirth = DateOfBirth, Gender = SelectedGender == 0 ? "Mужской" : "Женский", Experience = Experience, Position = Position, Cabinet = Cabinet, NumberOfPhone = NumberOfPhone };
                            user.DoctorProfile = person;
                            Account.RegistrationDoctor(user, person);
                          
                           
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
                   if (App.addNewDoctor != null)
                   {
                       App.addNewDoctor.Close();
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
