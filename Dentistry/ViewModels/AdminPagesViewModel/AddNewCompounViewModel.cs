﻿using Dentistry.Models;
using Dentistry.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.ViewModels.AdminPagesViewModel
{
    public class AddNewCompounViewModel : INotifyPropertyChanged
    {
        public static List<string> LastNamePatients = new List<string>();
        public static List<string> LastNameDoctors = new List<string>();
        public static List<string> Services = new List<string>();
        private DateTime _Date;
        public DateTime Date
        {
            get => _Date; set
            {
                _Date = value;
                OnPropertyChanged("Date");
            }
        }
        public string _LastNamePatient;
        public string LastNamePatient
        {
            get => _LastNamePatient; set
            {
                _LastNamePatient = value;
                OnPropertyChanged("LastNamePatient");
            }
        }
        public string _LastNameDoctor;
        public string LastNameDoctor
        {
            get => _LastNameDoctor; set
            {
                _LastNameDoctor = value;
                OnPropertyChanged("LastNameDoctor");
            }
        }
        public string _Service;
        public string Service
        {
            get => _Service; set
            {
                _Service = value;
                OnPropertyChanged("Service");
            }
        }
        public AddNewCompounViewModel()
        {
            
      
        }
        private RelayCommands _add;
        public RelayCommands Add
        {
            get
            {
                return
                _add ?? (
               _add = new RelayCommands(obj =>
               {
                   UnitOfWork unitOfWork = new UnitOfWork();
                   var service = unitOfWork.Services.GetAll().FirstOrDefault(x => x.Name== Service);
                   var doctor = unitOfWork.Doctors.GetAll().FirstOrDefault(x => x.LastName == LastNameDoctor);
                   var patient = unitOfWork.Patients.GetAll().FirstOrDefault(x => x.LastName == LastNamePatient);
                   Compoun compoun = new Compoun()
                   {
                       DateOfReception = Date,
                       DoctorId = doctor.Id,
                       PatientId = patient.Id

                   };
                   compoun.Services.Add(service);
                   unitOfWork.Compouns.Create(compoun);
                   unitOfWork.Save();

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