using Dentistry.Models;
using Dentistry.ViewModels;
using Dentistry.ViewModels.PatientPagesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry.Services
{
    public class OrderManager
    {
        public static void OrderCompoun(Doctor doctor,Compoun compoun)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var orderExist = unitOfWork.Compouns.GetAll().ToList().FindAll(x => x.TimeOfReception == compoun.TimeOfReception && x.IsOrder==true && x.DateOfReception == compoun.DateOfReception && x.DoctorId == doctor.Id);
            if(orderExist == null || orderExist.Count == 0)
            {
                
                
                unitOfWork.Compouns.Create(compoun);
                unitOfWork.Save();
                MessageBox.Show("Успешно добавлено");
                compoun.Doctor = doctor;
                PatientProfileViewModel.Compouns.Add(compoun);
            }
            else
            {
                MessageBox.Show("Талонов на это время уже нет");
            }
        }
        public static void OrderCompounAdmin(Doctor doctor, Compoun compoun, Patient patient)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var orderExist = unitOfWork.Compouns.GetAll().ToList().FindAll(x => x.TimeOfReception == compoun.TimeOfReception && x.IsOrder == true && x.DateOfReception == compoun.DateOfReception);
            if (orderExist == null || orderExist.Count == 0)
            {


                unitOfWork.Compouns.Create(compoun);
                unitOfWork.Save();
                MessageBox.Show("Успешно добавлено");
                compoun.Doctor = doctor;
                compoun.Patient = patient;
                Admin_CompounsViewModel.Compouns.Add(compoun);
            }
            else
            {
                MessageBox.Show("Талонов на это время уже нет");
            }
        }
    }
}
