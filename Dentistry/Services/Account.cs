using Dentistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Services
{
    class Account
    {
        private Account() { }


        private static Account _instance;

        public static Account GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Account();
            }
            return _instance;
        }

        public static void LogIn(string username, string password)
        {
            //Логика взаимодействия таблиц с пользователями и нашими данными введенными

            //Проверяем есть ли в бд такой пользователь
            if (false)
            {

            }
            //если нет, то выводим сообщение об ошибке
            else
            {

            }

            //

        }

        public static void Registration(string username, string password, string email)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            User user = new User();
            unitOfWork.User.Create(new User { UserName = username, Password = password, Email = email, TypeUser = "User" });
        }

    }
}
