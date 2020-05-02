using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dentistry.ViewModels
{
    public class RegistrationViewModel:INotifyPropertyChanged
    {
      
        private Page PatientType;
        private Page DoctorType;
        private Visibility _Visible;
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public Visibility Visible { get =>_Visible; set
            {
                _Visible = value;
                OnPropertyChanged("ChangeVisible");
            }
        }
        private string _SelectedItem;
        public string SelectedItem { get => _SelectedItem; set { _SelectedItem = value;
                OnPropertyChanged("Selected Type");
            } }
        public RegistrationViewModel()
        {
          
            PatientType = new Views.Registration.PatientType();
            DoctorType = new Views.Registration.DoctorType();
            Visible = Visibility.Visible;
        }

        private RelayCommands _ShowPage;
        public RelayCommands ShowPage
        {
            get
            { 
                return 
                _ShowPage ?? (
               _ShowPage = new RelayCommands(obj =>
                  {
                      CurrentPage = GetPage();
                 }));
            }
            
        }

        public Page GetPage()
        {
         
            if ( SelectedItem.Contains("Doctor"))
            {
                Visible = Visibility.Hidden;
                return DoctorType;
            }
            else
            {
                if (SelectedItem.Contains("Patient"))
                {
                    Visible = Visibility.Hidden;
                    return PatientType;
                }
                else MessageBox.Show("Choose the type!");
            }
            return null;
        }
        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
    }
}
