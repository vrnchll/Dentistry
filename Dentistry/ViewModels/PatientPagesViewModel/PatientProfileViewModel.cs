using Dentistry.Models;
using Dentistry.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels.PatientPagesViewModel 
{
    public class PatientProfileViewModel : INotifyPropertyChanged
    {
        public static BindingList<Compoun> Compouns;
        static PatientProfileViewModel()
        {
            Compouns = new BindingList<Compoun>();
        }
        private string _date;
        public string DateOfReception
        {
            get => _date; set
            {
                _date = value;
                OnPropertyChanged("DateOfReception");
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private string _time;
        public string TimeOfReception
        {
            get => _time; set
            {
                _time = value;
                OnPropertyChanged("TimeOfReception");
            }
        }

        public static string FirstName;
        public static string MiddleName;
        public static string LastName;
        public static string Gender;
        public static string DateOfBirthday;
        public static string NumberOfPhone;
        public static string City;
        public static string Street;
        public static string House;
        public static string Flat;
        public static string Login;
        private Visibility _changePanel = Visibility.Hidden;
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
                       if(NewPassword == NewConfirmPassword) { 
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
        private Compoun selectedCompoun;
        public Compoun SelectedCompoun
        {
            get
            {
                return selectedCompoun;
            }
            set
            {
                selectedCompoun = value;
                OnPropertyChanged("SelectedCompoun");
            }
        }

        private RelayCommands _cancelOrder;
        public RelayCommands CancelOrder
        {
            get
            {
                return
                _cancelOrder ?? (
               _cancelOrder = new RelayCommands(obj =>
               {
               if (SelectedCompoun != null)
                   { 
                   UnitOfWork unitOfWork = new UnitOfWork();
                   MessageBoxResult result = MessageBox.Show("Вы действительно желаете отменить заказ?", "Отмена", MessageBoxButton.YesNo, MessageBoxImage.Question);
                   if (selectedCompoun == null || result == MessageBoxResult.No) return;
                   if (SelectedCompoun.Status.Contains("Не выполнено"))
                   {
                       Compoun compoun = selectedCompoun as Compoun;
                       Compouns.Remove(compoun);
                       unitOfWork.Compouns.Delete(compoun.Id);
                       unitOfWork.Save();
                       OnPropertyChanged("Cancel");
                   }
                   else
                   {
                       MessageBox.Show("Вы не можете отменить данный талон!");
                   }
               }
                     else
                   {
                       MessageBox.Show("Вы не выбрали элемент!");
                   }
               }));
            }

        }
    }
}
