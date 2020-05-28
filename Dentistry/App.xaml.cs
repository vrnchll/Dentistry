using Dentistry.ViewModels;
using Dentistry.Views.Registration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Dentistry
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Window AuthorizationWindow;
        public static Window RegistrationWindow;

        public static Window DoctormainWindow;
        public static Window PatientmainWindow;
        public static RegistrationViewModel registrationViewModel;
        public static Window AdminWindow;

        static App()
        {
           
        }
        public static Window addNewCompoun;
        public static Window addNewDoctor;
        public static Window addNewPatient;
        public static Window addNewReception;
        public static Window addNewService;
      
    }
}
