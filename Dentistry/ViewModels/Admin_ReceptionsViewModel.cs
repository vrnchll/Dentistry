using Dentistry.Models;
using Dentistry.Services;
using Dentistry.ViewModels.AdminPagesViewModel;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.ViewModels
{
    class Admin_ReceptionsViewModel : INotifyPropertyChanged

    {
        public static BindingList<Reception> Receptions;
        private RelayCommands _Add;
        public RelayCommands Add
        {
            get
            {
                return
                _Add ?? (
               _Add = new RelayCommands(obj =>
               {
                   UnitOfWork unitOfWork = new UnitOfWork();
                   AddNewReceptionViewModel.ListServices = new BindingList<Service>(unitOfWork.Services.GetAll().ToList());

                   App.AddNewReception = new AddNewReception();
                   App.AddNewReception.Show();
               }));
            }

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
                    {
                        UnitOfWork unitOfWork = new UnitOfWork();
                        MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (selectedReception == null || result == MessageBoxResult.No) return;

                        Reception reception = selectedReception as Reception;
                        Receptions.Remove(reception);
                        unitOfWork.Receptions.Delete(reception.Id);
                        unitOfWork.Save();
                        OnPropertyChanged("Remove");
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
