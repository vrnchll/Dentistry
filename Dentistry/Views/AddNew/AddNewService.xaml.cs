﻿using Dentistry.Models;
using Dentistry.Services;
using Dentistry.ViewModels.AdminPagesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dentistry.Views
{
    /// <summary>
    /// Логика взаимодействия для AddNewService.xaml
    /// </summary>
    public partial class AddNewService : Window
    {
        public AddNewService(Service service = null)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            var doctors = unitOfWork.Doctors.GetAll().ToList();
            List<string> doctorsName = new List<string>();
            InitializeComponent();
            foreach (var i in doctors)
            {
                doctorsName.Add(i.LastName);
            }
            docList.ItemsSource = doctorsName;
            DataContext = new AddNewServiceViewModel(service);
        }
    }
}
