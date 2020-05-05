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

namespace Dentistry.Views
{
    /// <summary>
    /// Логика взаимодействия для Doctors.xaml
    /// </summary>
    public partial class Doctors : Page
    {
        public Doctors()
        {
            InitializeComponent();
            DataContext = new Admin_DoctorsViewModel();
        }
    }
}
