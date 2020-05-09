using Dentistry.Services;
using Dentistry.ViewModels.AdminPagesViewModel;
using Dentistry.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.ViewModels
{
    class Admin_CompounsViewModel : INotifyPropertyChanged
    {
        private RelayCommands _Add;
        public RelayCommands Add
        {
            get
            {
                return
                _Add ?? (
               _Add = new RelayCommands(obj =>
               {
                   UnitOfWork unitOfWork = new UnitOfWork();
                   var patients = unitOfWork.Patients.GetAll().ToList();
                   var doctors = unitOfWork.Doctors.GetAll().ToList();
                   var services = unitOfWork.Services.GetAll().ToList();
                   
                   foreach (var i in patients)
                   {
                       AddNewCompounViewModel.LastNamePatients.Add(i.LastName);
                   }
                   foreach (var i in doctors)
                   {
                       AddNewCompounViewModel.LastNameDoctors.Add(i.LastName);
                   }
                   foreach (var i in services)
                   {
                       AddNewCompounViewModel.Services.Add(i.Name);
                   }
                   AddNewCompoun newCompoun = new AddNewCompoun();
                   newCompoun.Show();
               }));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
