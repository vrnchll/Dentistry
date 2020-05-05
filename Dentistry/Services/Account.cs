using Dentistry.Models;
using Dentistry.ViewModels.DoctorPagesViewModel;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                            AdminMainWindow.Topmost = true;
                            AdminMainWindow.Show();
                        }break;
                    case "Doctor":
                        {
                            _instance = user;
                            ProfileDoctorInfo();
                            DoctorMainWindow DMainWindow = new DoctorMainWindow();
                            DMainWindow.Topmost = true;
                            DMainWindow.Show();
                        }break;
                    case "Patient":
                        {
                            _instance = user;
                            
                            PatientMainWindow PatientMainWindow = new PatientMainWindow();
                            PatientMainWindow.Topmost = true;
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
                unitOfWork.Save();
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
            }
        }
        public static void ProfileDoctorInfo()
        {
            DoctorProfileViewModel.FirstName = _instance.DoctorProfile.FirstName;
        }
    }
    }

