using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
using Dentistry.Views.DoctorPages;
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
    public class ReceptionsForDViewModel:INotifyPropertyChanged
    {
        public static BindingList<Reception> Receptions;
        private string _date;
        public string DateOfReception
        {
            get => _date; set
            {
                _date = value;
                OnPropertyChanged("DateOfReception");
            }
        }
        private string _time;
        public string TimeOfBeginReception
        {
            get => _time; set
            {
                _time = value;
                OnPropertyChanged("TimeOfBeggining");
            }
        }
        private string _timeE;
        public string TimeOfEndReception
        {
            get => _timeE; set
            {
                _timeE = value;
                OnPropertyChanged("TimeOfEnding");
            }
        }
        static ReceptionsForDViewModel()
        {
            Receptions = new BindingList<Reception>();
        }
       
        private Reception selectedReception;
        public Reception SelectedReception
        {
            get
            {
                return selectedReception;
            }
            set
            {
                selectedReception = value;
                OnPropertyChanged("SelectedReseption");
            }
        }
      
        private RelayCommands _removeCommand;
        public RelayCommands RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommands((selectedItem) =>
                    { if (selectedReception != null)
                        {
                            UnitOfWork unitOfWork = new UnitOfWork();
                            MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (selectedReception == null || result == MessageBoxResult.No) return;

                            Reception reception = selectedReception as Reception;
                            Receptions.Remove(reception);
                            unitOfWork.Receptions.Delete(reception.Id);
                            unitOfWork.Save();
                            OnPropertyChanged("Remove");
                        }
                    else
                        {
                                MessageBox.Show("Вы не выбрали элемент!");
                            
                        }
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

