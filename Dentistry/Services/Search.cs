using Dentistry.Models;
using Dentistry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.Services
{
    public class Search
    {
        public static void SearchPatients( string firstNames, string lastNames, string NumberOfphone, string DateOfBirthday)
        {
            // List<string> parms = new List<string>() {firstNames, lastNames, NumberOfphone, DateOfBirthday };
            // parms = parms.FindAll(x => x != null);
            // UnitOfWork unitOfWork = new UnitOfWork();
            // var patients = unitOfWork.Patients.GetAll().ToList() ;
            //if(patients!=null)
            // Admin_PatientsViewModel.Patients.Clear();
            // foreach (var pat in patients)
            // {
            //     foreach(string parm in parms)
            //     {
            //         if(parm)
            //     }

            //     ////если DateOfBirthDay 12.12.2020 14:00 DateOfBirthDay.toString("MM/dd/yyyy") == pat.DateOfBirth
            //     ////если DateOfBirthDay 12.12.2020 DateOfBirthday == DateTime.ParseExact(pat.DateOfBirth, "MM/dd/yyyy", null)
            //     //if ((string.IsNullOrWhiteSpace(firstNames)|| string.IsNullOrWhiteSpace(lastNames)|| string.IsNullOrWhiteSpace(NumberOfphone) || string.IsNullOrWhiteSpace(DateOfBirthday)) || (pat != null && pat.FirstName==firstNames || pat.LastName==lastNames || pat.NumberOfPhone==NumberOfphone || pat.DateOfBirth==DateOfBirthday))
            //     //{
            //     //    Admin_PatientsViewModel.Patients.Add(pat);
            //     //}
            // }
            // first select all not archived patiens
            UnitOfWork unitOfWork = new UnitOfWork();
            var patients = unitOfWork.Patients.GetAll();
            if (patients!=null)
            {
                if (!string.IsNullOrWhiteSpace(firstNames))
                {
                    patients = patients.Where(p => p.FirstName == firstNames);
                }

                if (!string.IsNullOrWhiteSpace(lastNames))
                {
                    patients = patients.Where(p => p.LastName == lastNames);
                }

                if (!string.IsNullOrWhiteSpace(NumberOfphone))
                {
                    patients = patients.Where(p => p.NumberOfPhone == NumberOfphone);
                }

                if (!string.IsNullOrWhiteSpace(DateOfBirthday))
                {
                    patients = patients.Where(p => p.DateOfBirth == DateOfBirthday);
                }
                Admin_PatientsViewModel.Patients.Clear();
                foreach (var patient in patients)
                    Admin_PatientsViewModel.Patients.Add(patient);

            }
            }
        }
        //public static void SearchServices(string param)
        //{
        //    UnitOfWork unitOfWork = new UnitOfWork();
        //    var services = unitOfWork.Services.GetAll().ToList();
        //    foreach (var ser in services)
        //    {
        //        if ((string.IsNullOrWhiteSpace(param) || ser != null && ser.Name.Contains(param) || ser.Cost.Contains(param) || ser.Doctors.Contains(param))
        //        {
        //            Admin_ServicesViewModel.Services.Add(ser);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Поле пусто!");
        //        }
        //    }
        //}
        }
    

