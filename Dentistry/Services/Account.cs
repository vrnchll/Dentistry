using Dentistry.Models;
using System;
using System.Collections.Generic;
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
                _instance = user;
                MainWindow MainWindow = new MainWindow();
                MainWindow.Topmost = true;
                MainWindow.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не найден, повторите попытку");
            }

            //

        }

        public static void RegistrationPatient(User user,Patient person)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.Users.Create(user);
            unitOfWork.Patients.Create(person);
        }

        public static void RegistrationDoctor(User user, Doctor person)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.Users.Create(user);
            unitOfWork.Doctors.Create(person);
            unitOfWork.Save();
        }
    }
    }

