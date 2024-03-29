﻿using Dentistry.Models;
using Dentistry.Views;
using Dentistry.Views.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dentistry.ViewModels
{
    public class RegistrationViewModel:INotifyPropertyChanged
    {
      
        private Page PatientType;
        private Page DoctorType;
        private Visibility _Visible;
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public Visibility Visible { get =>_Visible; set
            {
                _Visible = value;
                OnPropertyChanged("ChangeVisible");
            }
        }
        private string _SelectedItem;
        public string SelectedItem {

            get => _SelectedItem;
            set {
   
                _SelectedItem = value;
                OnPropertyChanged("Selected Type");
            } }
        public RegistrationViewModel()
        {
          
            PatientType = new PatientType();
            DoctorType = new DoctorType();
            Visible = Visibility.Visible;
        }

        private RelayCommands _ShowPage;
        public RelayCommands ShowPage
        {
            get
            { 
                return 
                _ShowPage ?? (
               _ShowPage = new RelayCommands(obj =>
                  {
                      CurrentPage = GetPage();
                 }));
            }
            
        }
        private RelayCommands _ReturnBack;
        public RelayCommands ReturnBack
        {
            get
            {
                return
                _ReturnBack ?? (
               _ReturnBack = new RelayCommands(obj =>
               {


                   App.Current.MainWindow.Visibility = Visibility.Visible;
                   App.RegistrationWindow.Visibility = Visibility.Hidden;
                   
               }));
            }

        }
        public Page GetPage()
        {
         
            if ( SelectedItem.Contains("Доктор"))
            {
                Visible = Visibility.Hidden;
                return DoctorType;
            }
            else
            {
                if (SelectedItem.Contains("Пациент"))
                {
                    Visible = Visibility.Hidden;
                    return PatientType;
                }
                else MessageBox.Show("Choose the type!");
            }
            return null;
        }
        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
    }
}
