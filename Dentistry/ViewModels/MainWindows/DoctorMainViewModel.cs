using Dentistry.Views;
using Dentistry.Views.DoctorPages;
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
    class DoctorMainViewModel : INotifyPropertyChanged
    {
       

        
        private Page AddReception;
        private Page Receptions;
        private Page Compouns;
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
        public DoctorMainViewModel()
        {

            AddReception = new AddNewReceptionForDoctor();
            Receptions = new ReceptionsForD();
            Compouns = new CompounsForD();
            Profile = new ProfileD();
            CurrentPage = AddReception;

            
         
        }

        private RelayCommands _addReception;
        public RelayCommands AddNewReception
        {
            get
            {
                return
                _addReception ?? (
               _addReception = new RelayCommands(obj =>
               {
                   CurrentPage = AddReception;
               }));
            }
        }

        private RelayCommands _showReceptions;
        public RelayCommands ShowReceptions
        {
            get
            {
                return
                _showReceptions ?? (
               _showReceptions = new RelayCommands(obj =>
               {
                   CurrentPage = Receptions;
               }));
            }

        }
        private RelayCommands _ShowCompoun;
        public RelayCommands ShowCompoun
        {
            get
            {
                return
                _ShowCompoun ?? (
               _ShowCompoun = new RelayCommands(obj =>
               {
                   CurrentPage = Compouns;
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
