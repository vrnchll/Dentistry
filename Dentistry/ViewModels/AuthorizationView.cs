using Dentistry.Services;
using Dentistry.Views;
using Dentistry.Views.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dentistry.ViewModels
{
    class AuthorizationView : INotifyPropertyChanged
    {
        private string _userName;
        private string _password;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private RelayCommands signInCommand;
        public RelayCommands SignInCommand
        {
            get
            {
                return signInCommand ??
                  (signInCommand = new RelayCommands(obj =>
                  {
                      var passwordBox = obj as PasswordBox;
                      if (passwordBox == null)
                          return;
                      Password = passwordBox.Password;
                      Account.LogIn(UserName, Password);
                  }));
            }
        }
        private RelayCommands signUpCommand;
        public RelayCommands SignUpCommand
        {
            get
            {
                return signUpCommand ??
                  (signUpCommand = new RelayCommands(obj =>
                  {
                     
                    App.RegistrationWindow = new Registration();
                      App.RegistrationWindow.Show();
                      App.Current.MainWindow.Close();
                     

                  }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
