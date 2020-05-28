using Dentistry.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels.DoctorPagesViewModel
{
    public class DoctorProfileViewModel : INotifyPropertyChanged
    {

        public static string FirstName;
        public static string MiddleName;
        public static string LastName;
        public static string Gender;
        public static string DateOfBirthday;
        public static string NumberOfPhone;
        public static string Position;
        public static string Experience;
        public static string Cabinet;
        public static string Login;
        public static string Password;
        public static string ConfirmPassword;
        private Visibility _changePanel=Visibility.Hidden;
        public Visibility ChangePanel
        {
            get { return _changePanel; }
            set
            {
                _changePanel = value;
                OnPropertyChanged("ChangePanel");
            }
        }
        private string _NewPassword;
        public string NewPassword
        {
            get => _NewPassword; set
            {
                _NewPassword = value;
                OnPropertyChanged("NewPassword");
            }
        }
        private string _NewConfirmPassword;
        public string NewConfirmPassword
        {
            get => _NewConfirmPassword; set
            {
                _NewConfirmPassword = value;
                OnPropertyChanged("NewConfirmPassword");
            }
        }
        private string _NewLogin;
        public string NewLogin
        { 
            get => _NewLogin; set
            {
                _NewLogin = value;
                OnPropertyChanged("NewLogin");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private RelayCommands _ShowChangingGrid;
        public RelayCommands ShowChangingGrid
        {
            get
            {
                return
                _ShowChangingGrid ?? (
               _ShowChangingGrid = new RelayCommands(obj =>
               {
                   if (ChangePanel == Visibility.Hidden)
                   {
                       ChangePanel = Visibility.Visible;
                   }
                   else
                   {
                       ChangePanel = Visibility.Hidden;
                   }

               }));
            }

        }
        private RelayCommands _Change;
        public RelayCommands Change
        {
            get
            {
                return
                _Change ?? (
               _Change = new RelayCommands(obj =>
               {
                   if (!String.IsNullOrEmpty(NewPassword) && !String.IsNullOrEmpty(NewConfirmPassword))
                   {
                       if (NewPassword == NewConfirmPassword)
                       {
                           Account.ChangeInformation(NewPassword, NewLogin);
                           ChangePanel = Visibility.Hidden;
                       }
                       else
                       {
                           MessageBox.Show("Пароли не совпадают");
                       }
                   }
                   else
                   {
                       Account.ChangeInformation(NewPassword, NewLogin);
                       ChangePanel = Visibility.Hidden;
                   }
               }));
            }

        }
    }
}
