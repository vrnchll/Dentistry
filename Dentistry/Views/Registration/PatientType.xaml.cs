using Dentistry.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PatientType.xaml
    /// </summary>
    public partial class PatientType : Page
    {
        public PatientType()
        {
            
            InitializeComponent();
            CityNames.ItemsSource = GetCities();
            DataContext = new PatientViewModel();
        }

        public List<string> GetCities()
        {
            List<string> citiesList = new List<string>();
            FileInfo file = new FileInfo($"{Environment.CurrentDirectory}\\cities.txt");
            string[] cities = File.ReadAllLines($"{ Environment.CurrentDirectory}\\cities.txt", Encoding.GetEncoding(1251));
            foreach(string city in cities)
            {
                citiesList.Add(city);
            }
            return citiesList;
        }
    }
}
