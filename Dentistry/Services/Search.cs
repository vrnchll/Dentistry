using Dentistry.Models;
using Dentistry.ViewModels;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Dentistry.Services
{
    public class Search
    {
        public static void SearchPatients(string firstNames, string lastNames, string NumberOfphone, string DateOfBirthday)
        {
            UnitOfWork unitofwork = new UnitOfWork();
            var patients = unitofwork.Patients.GetAll();
            Admin_PatientsViewModel.Patients.Clear();
            foreach (var patient in patients)
            {
                if ((firstNames == null ? true : firstNames == patient.FirstName)
                        && (lastNames == null ? true : lastNames == patient.LastName)
                        && (NumberOfphone == null ? true : NumberOfphone == patient.NumberOfPhone)
                        && (DateOfBirthday == null ? true : DateOfBirthday == patient.DateOfBirth)
                        )
                {
                    Admin_PatientsViewModel.Patients.Add(patient);

                }
            }

        }
        public static void SearchServices(string param)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var services = unitOfWork.Services.GetAll().ToList();
            Admin_ServicesViewModel.Services.Clear();
            foreach (var service in unitOfWork.Services.Include())
            {
                foreach (var person in service.Doctors.ToList())
                {
                    if (param == null ? true : service.Name.Contains(param) ||
                                       param == null ? true : service.Cost.Contains(param))
                    {
                        service.Doctors.Add(person);
                        Admin_ServicesViewModel.Services.Add(service);

                    }


                }

            }

        }

        public static void SearchDoctor(string firstNames, string lastNames, string experiences, string DateOfBirthday)
        {
            UnitOfWork unitofwork = new UnitOfWork();
            var doctors = unitofwork.Doctors.GetAll();
            Admin_DoctorsViewModel.Doctors.Clear();
            foreach (var doctor in doctors)
            {
                if ((firstNames == null ? true : firstNames == doctor.FirstName)
                        && (lastNames == null ? true : lastNames == doctor.LastName)
                        && (experiences == null ? true : experiences == doctor.Experience.ToString())
                        && (DateOfBirthday == null ? true : DateOfBirthday == doctor.DateOfBirth)
                        )
                {
                    Admin_DoctorsViewModel.Doctors.Add(doctor);

                }
            }
        }
        public static void SearchCompouns(string DateofRe, string PatientLNs, string DoctorLNs)
        {
            UnitOfWork unitofwork = new UnitOfWork();
            var compouns = unitofwork.Compouns.GetAll().ToList();

            foreach (var compoun in compouns)
            {
                Doctor doctor = unitofwork.Doctors.GetAll().FirstOrDefault(x => x.Id == compoun.DoctorId);
                Patient patient = unitofwork.Patients.GetAll().FirstOrDefault(x => x.Id == compoun.PatientId);
                if (doctor != null && patient != null)
                {
                    compoun.Doctor = doctor;
                    compoun.Patient = patient;
                }
            }
            Admin_CompounsViewModel.Compouns.Clear();
            foreach (var compoun in compouns)
            {
                if ((DateofRe == null ? true : DateofRe == compoun.DateOfReception)
                        && (PatientLNs == null ? true : PatientLNs == compoun.Patient.LastName)
                        && (DoctorLNs == null ? true : DoctorLNs == compoun.Doctor.LastName)
                        )
                {
                    Admin_CompounsViewModel.Compouns.Add(compoun);

                }
            }
        }
        public static void SearchReception(string NameService, string PatientLNs, string DoctorLNs)
        {
            UnitOfWork unitofwork = new UnitOfWork();
            var receptions = unitofwork.Receptions.GetAll().ToList();
            foreach (var reception in receptions)
            {
                Doctor doctor = unitofwork.Doctors.GetAll().FirstOrDefault(x => x.Id == reception.DoctorId);
                Patient patient = unitofwork.Patients.GetAll().FirstOrDefault(x => x.Id == reception.PatientId);
                Service service = unitofwork.Services.GetAll().FirstOrDefault(x => x.Id == reception.ServiceId);
                if (doctor != null && patient != null && service != null)
                {
                    reception.Doctor = doctor;
                    reception.Patient = patient;
                    reception.Service = service;
                }
            }
            Admin_ReceptionsViewModel.Receptions.Clear();
            foreach (var recep in receptions)
            {
                if ((NameService == null ? true : NameService == recep.Service.Name)
                        && (PatientLNs == null ? true : PatientLNs == recep.Patient.LastName)
                        && (DoctorLNs == null ? true : DoctorLNs == recep.Doctor.LastName)
                        )
                {
                    Admin_ReceptionsViewModel.Receptions.Add(recep);

                }
            }
        }
    }
}

    

