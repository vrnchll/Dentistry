﻿using Dentistry.Context;
using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;


namespace Dentistry.ViewModels
{
    class Admin_DoctorsViewModel : INotifyPropertyChanged
    {
        public static BindingList<Doctor> Doctors;
      

        private static ProjectContext db = new ProjectContext();

        private string _FirstName;
        static Admin_DoctorsViewModel()
        {
            Doctors = new BindingList<Doctor>();
        }

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
                   App.addNewDoctor = new AddNewDoctor();
                   App.addNewDoctor.Show();
               
                  
               }));
            }

        }
        private Doctor selectedDoctor;
        public Doctor SelectedDoctor
        {
            get
            {
                return selectedDoctor;
            }
            set
            {
                selectedDoctor = value;
                OnPropertyChanged("SelectedDoctor");
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
                        if (SelectedDoctor != null)
                        {
                            App.addNewDoctor = new AddNewDoctor(SelectedDoctor);
                            App.addNewDoctor.Show();
                            OnPropertyChanged("Edit");
                        }
                        else
                        {
                            MessageBox.Show("Вы не выбрали элемент!");
                        }
                    }));
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
                   if (SelectedDoctor != null)
                   {
                       UnitOfWork unitOfWork = new UnitOfWork();
                       MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                       if (selectedDoctor == null || result == MessageBoxResult.No) return;
                      
                       Doctor doctor = selectedDoctor as Doctor;
                       Doctors.Remove(doctor);
                       unitOfWork.Doctors.Delete(doctor.Id);
                       var compouns = unitOfWork.Compouns.GetAll();
                       foreach(var compoun in compouns)
                       {
                           if (compoun.DoctorId == doctor.Id)
                               unitOfWork.Compouns.Delete(compoun.Id);
                       }
                           var recep = unitOfWork.Receptions.GetAll();
                           foreach (var rec in recep)
                           {
                               if (rec.DoctorId == doctor.Id)
                                   unitOfWork.Receptions.Delete(rec.Id);
                           }

                           unitOfWork.Users.Delete(doctor.Id);
                       unitOfWork.Save();
                       OnPropertyChanged("Remove");
                       }
                       else
                       {
                           MessageBox.Show("Вы не выбрали элемент!");
                       }
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
        private string _Experiences;
        public string Experiences
        {
            get
            {
                return _Experiences;
            }
            set
            {
                _Experiences = value;
                OnPropertyChanged("Experiences");
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
                   Search.SearchDoctor(FirstNames == "" ? null : FirstNames, LastNames == "" ? null : LastNames, Experiences == "" ? null : Experiences, DateOfBirthd == "" ? null : DateOfBirth);
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
                   var doctors = unitOfWork.Doctors.GetAll().ToList();
                   Admin_DoctorsViewModel.Doctors.Clear();
                   foreach (var doctor in doctors)
                   {
                       Doctors.Add(doctor);
                   }
               }));
            }

        }
        //------------------------------


        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
