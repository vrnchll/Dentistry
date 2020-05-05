using Dentistry.Views.PatientPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dentistry.ViewModels.MainWindows
{
    public class PatientMainViewModel:INotifyPropertyChanged
    {
        private Page AddCompoun;
        private Page Doctors;
        private Page Services;
        private Page Profile;
        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged("CurrentPage");

            }
        }
        public PatientMainViewModel()
        {
            AddCompoun = new AddCompounForP();
            Doctors = new DoctorsForP();
            Services = new ServicesForP();
            Profile = new Profile();
            CurrentPage = AddCompoun;
        }

        private RelayCommands _addCompoun;
        public RelayCommands AddNewCompoun
        {
            get
            {
                return
                _addCompoun ?? (
               _addCompoun = new RelayCommands(obj =>
               {
                   CurrentPage = AddCompoun;
               }));
            }
        }

        private RelayCommands _showDoctors;
        public RelayCommands ShowDoctors
        {
            get
            {
                return
                _showDoctors ?? (
               _showDoctors = new RelayCommands(obj =>
               {
                   CurrentPage = Doctors;
               }));
            }

        }
        private RelayCommands _ShowServices;
        public RelayCommands ShowServices
        {
            get
            {
                return
                _ShowServices ?? (
               _ShowServices = new RelayCommands(obj =>
               {
                   CurrentPage = Services;
               }));
            }

        }
        private RelayCommands _ShowProfile;
        public RelayCommands ShowProfile
        {
            get
            {
                return
                _ShowProfile ?? (
               _ShowProfile = new RelayCommands(obj =>
               {
                   CurrentPage = Profile;
               }));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
}
