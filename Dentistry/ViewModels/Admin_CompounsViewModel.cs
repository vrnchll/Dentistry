﻿using Dentistry.Context;
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
        static Admin_CompounsViewModel()
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

        private bool _status;
        public bool Status
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
                  
                   
                   App.addNewCompoun = new AddNewCompoun();
                   App.addNewCompoun.Show();
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
        private RelayCommands _EditCommand;
        public RelayCommands EditCommand
        {
            get
            {
                return _EditCommand ??
                    (_EditCommand = new RelayCommands((selectedItem) =>
                    {
                        if (SelectedCompoun != null)
                        {
                            App.addNewCompoun = new AddNewCompoun(SelectedCompoun);
                            App.addNewCompoun.Show();
                            OnPropertyChanged("Edit");
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
                    if (SelectedCompoun != null)
                    {
                        UnitOfWork unitOfWork = new UnitOfWork();
                        MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (selectedCompoun == null || result == MessageBoxResult.No) return;

                        Compoun compoun = selectedCompoun as Compoun;
                        Compouns.Remove(compoun);
                        unitOfWork.Compouns.Delete(compoun.Id);
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

        private string _DateOfR;
        public string DateOfR
        {
            get
            {
                return _DateOfR;
            }
            set
            {
                _DateOfR = value;
                OnPropertyChanged("DateOfR");
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
                   Search.SearchCompouns(DateOfR == "" ? null : DateOfR, PatientLN == "" ? null : PatientLN, DoctorLN == "" ? null : DoctorLN);
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
                   var compouns = unitOfWork.Compouns.GetAll().ToList();
                   Admin_CompounsViewModel.Compouns.Clear();
                   foreach (var com in compouns)
                   {
                       var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.Id == com.PatientId);
                       com.Patient = patient;
                       var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.Id == com.DoctorId);
                       com.Doctor = doctor;
                       Compouns.Add(com);
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
