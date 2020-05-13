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
    /// Логика взаимодействия для Compouns.xaml
    /// </summary>
    public partial class Compouns : Page
    {
        public Compouns()
        {
            InitializeComponent();
            DataContext = new Admin_CompounsViewModel();
            CompounsList.ItemsSource = Admin_CompounsViewModel.Compouns;
        }
    }
}
