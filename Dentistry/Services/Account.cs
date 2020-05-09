using Dentistry.Models;
using Dentistry.ViewModels;
using Dentistry.ViewModels.DoctorPagesViewModel;
using Dentistry.ViewModels.PatientPagesViewModel;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.Services
{
    class Account
    {
        private Account() { }


        private static User _instance;

        public static User GetInstance()
        {
            if (_instance == null)
            {
                _instance = new User();
            }
            return _instance;
        }

        public static void LogIn(string username, string password)
        {
            //Логика взаимодействия таблиц с пользователями и нашими данными введенными
            
            UnitOfWork unitOfWork = new UnitOfWork();
            var user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.UserName == username && x.Password == password);
            
            if (user != null)
            {
                switch (user.TypeUser)
                {
                    case "Admin": {
                            _instance = user;
                            AdminMainWindow AdminMainWindow = new AdminMainWindow();
                            AdminMainWindow.Show();
                        }break;
                    case "Doctor":
                        {
                            var person = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == user.Id);
                            user.DoctorProfile = person;
                            _instance = user;
                            ProfileDoctorInfo();
                            DoctorMainWindow DMainWindow = new DoctorMainWindow();
                            DMainWindow.Show();
                        }break;
                    case "Patient":
                        {
                            var person = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == user.Id);
                            user.PatientProfile = person;
                            _instance = user;
                            ProfilePatientInfo();
                            PatientMainWindow PatientMainWindow = new PatientMainWindow();
                            PatientMainWindow.Show();
                        }break;
                    default: break;
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден, повторите попытку");
            }

            //

        }

        public static void RegistrationPatient(User user,Patient person)
        {
            var resultsUser = new List<ValidationResult>();
            var contextUser = new ValidationContext(user);
            var resultsPerson = new List<ValidationResult>();
            var contextPerson = new ValidationContext(person);
            if (!Validator.TryValidateObject(user, contextUser, resultsUser, true) && !Validator.TryValidateObject(person, contextPerson, resultsPerson, true))
            {
                foreach (var error in resultsUser)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
                foreach (var error in resultsPerson)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
            else
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Users.Create(user);
                unitOfWork.Patients.Create(person);
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    unitOfWork.Save();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                
                Admin_PatientsViewModel.Patients.Add(person);
            }
          
          
          
        }

        public static void RegistrationDoctor(User user, Doctor person)
        {
            var resultsUser = new List<ValidationResult>();
            var contextUser = new ValidationContext(user);
            var resultsPerson = new List<ValidationResult>();
            var contextPerson = new ValidationContext(person);
            if (!Validator.TryValidateObject(user, contextUser, resultsUser, true) && !Validator.TryValidateObject(person, contextPerson, resultsPerson, true))
            {
                foreach (var error in resultsUser)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
                foreach (var error in resultsPerson)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
            else
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Users.Create(user);
                unitOfWork.Doctors.Create(person);
                unitOfWork.Save();
                Admin_DoctorsViewModel.Doctors.Add(person);
            }
        }
        public static void ProfileDoctorInfo()
        {
            DoctorProfileViewModel.FirstName = _instance.DoctorProfile.FirstName;
            DoctorProfileViewModel.MiddleName = _instance.DoctorProfile.MiddleName;
            DoctorProfileViewModel.LastName = _instance.DoctorProfile.LastName;
            DoctorProfileViewModel.Gender = _instance.DoctorProfile.Gender;
            DoctorProfileViewModel.DateOfBirthday = _instance.DoctorProfile.DateOfBirth;
            DoctorProfileViewModel.Position = _instance.DoctorProfile.Position;
            DoctorProfileViewModel.Experience = _instance.DoctorProfile.Experience;
            DoctorProfileViewModel.Cabinet = _instance.DoctorProfile.Cabinet;
            DoctorProfileViewModel.NumberOfPhone = _instance.DoctorProfile.NumberOfPhone;
            DoctorProfileViewModel.Login = _instance.DoctorProfile.User.UserName;
        }
        public static void ProfilePatientInfo()
        {
            PatientProfileViewModel.FirstName = _instance.PatientProfile.FirstName;
            PatientProfileViewModel.MiddleName = _instance.PatientProfile.MiddleName;
            PatientProfileViewModel.LastName = _instance.PatientProfile.LastName;
            PatientProfileViewModel.Gender = _instance.PatientProfile.Gender;
            PatientProfileViewModel.DateOfBirthday = _instance.PatientProfile.DateOfBirth;
            PatientProfileViewModel.City = _instance.PatientProfile.City;
            PatientProfileViewModel.Street = _instance.PatientProfile.Street;
            PatientProfileViewModel.House= _instance.PatientProfile.House;
            PatientProfileViewModel.Flat= _instance.PatientProfile.Flat;
            PatientProfileViewModel.NumberOfPhone = _instance.PatientProfile.NumberOfPhone;
            PatientProfileViewModel.Login = _instance.PatientProfile.User.UserName;
        }
    }
    }

