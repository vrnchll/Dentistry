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
    public class Admin_ReceptionsViewModel : INotifyPropertyChanged

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
        static Admin_ReceptionsViewModel()
        {
            Receptions = new BindingList<Reception>();
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
                   var services = unitOfWork.Services.GetAll().ToList();
                   foreach (var i in patients)
                   {
                       AddNewReceptionViewModel.LastNamePatients.Add(i.LastName);
                   }
                   foreach (var i in doctors)
                   {
                       AddNewReceptionViewModel.LastNameDoctors.Add(i.LastName);
                   }
                   foreach (var i in services)
                   {
                       AddNewReceptionViewModel.ServicesNames.Add(i.Name);
                   }
                   App.addNewReception = new AddNewReception();
                   App.addNewReception.Show();
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
        private RelayCommands _EditCommand;
        public RelayCommands EditCommand
        {
            get
            {
                return _EditCommand ??
                    (_EditCommand = new RelayCommands((selectedItem) =>
                    {
                        if (SelectedReception != null)
                        {
                            App.addNewReception = new AddNewReception(SelectedReception);
                            App.addNewReception.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("Вы не выбрали элемент!");
                        }
                    }));
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
                    if (SelectedReception != null)
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

        //Search

        private string _NamesService;
        public string NamesService
        {
            get
            {
                return _NamesService;
            }
            set
            {
                _NamesService = value;
                OnPropertyChanged("NamesService");
            }
        }
        private string _PatientLN;
        public string PatientLN
        {
            get
            {
                return _PatientLN;
            }
            set
            {
                _PatientLN = value;
                OnPropertyChanged("PatientLN");
            }
        }
        private string _DoctorLN;
        public string DoctorLN
        {
            get
            {
                return _DoctorLN;
            }
            set
            {
                _DoctorLN = value;
                OnPropertyChanged("DoctorLN");
            }
        }

        private RelayCommands _SearchCommand;
        public RelayCommands SearchCommand
        {
            get
            {
                return
                _SearchCommand ?? (
               _SearchCommand = new RelayCommands(obj =>
               {
                   Search.SearchReception(NamesService == "" ? null : NamesService, PatientLN == "" ? null : PatientLN, DoctorLN == "" ? null : DoctorLN);
               }));

            }

        }
        private RelayCommands _Clear;
        public RelayCommands Clear
        {
            get
            {
                return
                _Clear ?? (
               _Clear = new RelayCommands(obj =>
               {
                   UnitOfWork unitOfWork = new UnitOfWork();
                   Receptions.Clear();
                   var receptions = unitOfWork.Receptions.GetAll().ToList();
                   foreach (var rec in receptions)
                   {
                       var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == rec.PatientId);
                       rec.Patient = patient;
                       var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == rec.DoctorId);
                       rec.Doctor = doctor;
                       var service = unitOfWork.Services.GetAll().FirstOrDefault(x => x.Id == rec.ServiceId);
                       rec.Service = service;
                       Receptions.Add(rec);
                   }
               }));
            }

        }
        //------------------------------
        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
