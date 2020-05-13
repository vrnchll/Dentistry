using Dentistry.Context;
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
    public class Admin_CompounsViewModel : INotifyPropertyChanged
    {
        public static BindingList<Compoun> Compouns;
        public Admin_CompounsViewModel()

            {
            Compouns = new BindingList<Compoun>();
            }
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
                   var patients = unitOfWork.Patients.GetAll().ToList();
                   var doctors = unitOfWork.Doctors.GetAll().ToList();
                   
                   
                   foreach (var i in patients)
                   {
                       AddNewCompounViewModel.LastNamePatients.Add(i.LastName);
                   }
                   foreach (var i in doctors)
                   {
                       AddNewCompounViewModel.LastNameDoctors.Add(i.LastName);
                   }
                  
                   
                   App.AddNewCompoun = new AddNewCompoun();
                   App.AddNewCompoun.Show();
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
                        if (selectedCompoun == null || result == MessageBoxResult.No) return;

                        Compoun compoun = selectedCompoun as Compoun;
                        Compouns.Remove(compoun);
                        unitOfWork.Compouns.Delete(compoun.Id);
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
