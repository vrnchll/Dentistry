﻿using Dentistry.ViewModels;
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

namespace Dentistry.Views.Registration
{
    /// <summary>
    /// Логика взаимодействия для DoctorType.xaml
    /// </summary>
    public partial class DoctorType : Page
    {
        public DoctorType()
        {
            InitializeComponent();
            DataContext = new DoctorViewModel();
        }
    }
}
