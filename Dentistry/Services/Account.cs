using Dentistry.Models;
using Dentistry.ViewModels;
using Dentistry.ViewModels.DoctorPagesViewModel;
using Dentistry.ViewModels.PatientPagesViewModel;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.Services
{
    public class Account
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
            String tmp = Encrypt(password, username);
            UnitOfWork unitOfWork = new UnitOfWork();
            var user = unitOfWork.Users.GetAll().FirstOrDefault(x => x.UserName == username && x.Password == tmp);
            
            if (user != null)
            {
                switch (user.TypeUser)
                {
                    case "Admin": {
                            _instance = user;
                            
                            App.AdminWindow = new AdminMainWindow();
                            App.AdminWindow.Show();
                            App.Current.MainWindow.Visibility = Visibility.Hidden;
                        }
                        break;
                    case "Doctor":
                        {
                            var person = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == user.Id);
                            user.DoctorProfile = person;
                            _instance = user;
                            ProfileDoctorInfo();
                            App.DoctormainWindow = new DoctorMainWindow();
                            App.DoctormainWindow.Show();
                            App.Current.MainWindow.Visibility = Visibility.Hidden;
                        }
                        break;
                    case "Patient":
                        {
                            var person = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == user.Id);
                            user.PatientProfile = person;
                            _instance = user;
                            ProfilePatientInfo();
                            App.PatientmainWindow = new PatientMainWindow();
                            App.PatientmainWindow.Show();
                            App.Current.MainWindow.Visibility = Visibility.Hidden;
                        }
                        break;
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
            if (!Validator.TryValidateObject(user, contextUser, resultsUser, true) || !Validator.TryValidateObject(person, contextPerson, resultsPerson, true))
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
                String tmp = Encrypt(user.Password, user.UserName);
                user.Password = tmp;
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Users.Create(user);
                unitOfWork.Patients.Create(person);
                unitOfWork.Save();
                Admin_PatientsViewModel.Patients.Add(person);
                if (App.RegistrationWindow != null)
                {
                    App.RegistrationWindow.Visibility = Visibility.Hidden;
                    App.Current.MainWindow.Visibility = Visibility.Visible;
                }
            }
          
          
          
        }

        public static void RegistrationDoctor(User user, Doctor person)
        {
            var resultsUser = new List<ValidationResult>();
            var contextUser = new ValidationContext(user);
            var resultsPerson = new List<ValidationResult>();
            var contextPerson = new ValidationContext(person);
            if (!Validator.TryValidateObject(user, contextUser, resultsUser, true) || !Validator.TryValidateObject(person, contextPerson, resultsPerson, true))
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
                String tmp = Encrypt(user.Password, user.UserName);
                user.Password = tmp;
                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.Users.Create(user);
                unitOfWork.Doctors.Create(person);
                unitOfWork.Save();
                Admin_DoctorsViewModel.Doctors.Add(person);
                if (App.RegistrationWindow != null)
                {
                    App.RegistrationWindow.Visibility = Visibility.Hidden;
                    App.Current.MainWindow.Visibility = Visibility.Visible;
                }
                
            }
        }

        public static void ChangeInformation(string NewUserName, string NewPassword)
        {
            String tmp = Encrypt(NewPassword,NewUserName);
            _instance.Password = tmp;
            _instance.UserName = NewUserName;
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.Users.Update(_instance);
            unitOfWork.Save();
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
            DoctorProfileViewModel.Password = _instance.DoctorProfile.User.Password;
           
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
        public static string Encrypt(string ishText, string pass, string sol = "dentistry", string cryptographicAlgorithm = "SHA1", int passIter = 2, string initVec = "a8doSuDitOz1hZe#", int keySize = 256)
        {
            if (string.IsNullOrEmpty(ishText))
                return "";

            byte[] initVecB = Encoding.ASCII.GetBytes(initVec);
            byte[] solB = Encoding.ASCII.GetBytes(sol);
            byte[] ishTextB = Encoding.UTF8.GetBytes(ishText);

            PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, solB, cryptographicAlgorithm, passIter);
            byte[] keyBytes = derivPass.GetBytes(keySize / 8);
            RijndaelManaged symmK = new RijndaelManaged();
            symmK.Mode = CipherMode.CBC;

            byte[] cipherTextBytes = null;

            using (ICryptoTransform encryptor = symmK.CreateEncryptor(keyBytes, initVecB))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(ishTextB, 0, ishTextB.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memStream.ToArray();
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }

            symmK.Clear();
            return Convert.ToBase64String(cipherTextBytes);
        }
        

    }
}

