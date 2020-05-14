using Dentistry.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.ViewModels.AdminPagesViewModel
{
    public class AddNewReceptionViewModel : INotifyPropertyChanged
    {
        public static BindingList<Service> ListServices;
      
        






        private RelayCommands _add;
        public RelayCommands Add
        {
            get
            {
                return
                _add ?? (
               _add = new RelayCommands(obj =>
               {

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
