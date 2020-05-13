using Dentistry.Context;
using Dentistry.Models;
using Dentistry.Services;
using Dentistry.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;


namespace Dentistry.ViewModels
{
    class Admin_DoctorsViewModel : INotifyPropertyChanged
    {
        public static BindingList<Doctor> Doctors;
        public static BindingList<string> LastNames;
        public static BindingList<string> FirstNames;
        public static BindingList<string> Experiences;
        public static BindingList<string> DateOfBirthd;

        private static ProjectContext db = new ProjectContext();

        private string _FirstName;
        static Admin_DoctorsViewModel()
        {
            Doctors = new BindingList<Doctor>();
            LastNames = new BindingList<string>();
            FirstNames = new BindingList<string>();
            Experiences = new BindingList<string>();
            DateOfBirthd = new BindingList<string>();
        }

        public string FirstName
        {
            get => _FirstName; set
            {
                _FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName; set
            {
                _LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private string _MiddleName;
        public string MiddleName
        {
            get => _MiddleName; set
            {
                _MiddleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private DateTime _DateOfBirth;
        public DateTime DateOfBirth
        {
            get => _DateOfBirth; set
            {
                _DateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        private bool[] _Gender = new bool[] { true, false };
        public bool[] Gender { get => _Gender; }
        public int SelectedGender { get => Array.IndexOf(_Gender, true); }

        private string _Position;
        public string Position
        {
            get => _Position; set
            {
                _Position = value;
                OnPropertyChanged("Position");
            }
        }
        private string _Experience;
        public string Experience
        {
            get => _Experience; set
            {
                _Experience = value;
                OnPropertyChanged("Experience");
            }
        }

        private string _NumberOfPhone;
        public string NumberOfPhone
        {
            get => _NumberOfPhone; set
            {
                _NumberOfPhone = value;
                OnPropertyChanged("NumberOfPhone");
            }
        }

        private string _Cabinet;
        public string Cabinet
        {
            get => _Cabinet; set
            {
                _Cabinet = value;
                OnPropertyChanged("Cabinet");
            }
        }

        private string _Login;
        public string Login
        {
            get => _Login; set
            {
                _Login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _Password;
        public string Password
        {
            get => _Password; set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }
        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            get => _ConfirmPassword; set
            {
                _ConfirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private string _Email;
        public string Email
        {
            get => _Email; set
            {
                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        private RelayCommands _Add;
        public RelayCommands Add
        {
            get
            {
                return
                _Add ?? (
               _Add = new RelayCommands(obj =>
               {
                   App.AddNewDoctor = new AddNewDoctor();
                   App.AddNewDoctor.Show();
               
                  
               }));
            }

        }
        private Doctor selectedDoctor;
        public Doctor SelectedDoctor
        {
            get
            {
                return selectedDoctor;
            }
            set
            {
                selectedDoctor = value;
                OnPropertyChanged("SelectedDoctor");
            }
        }
       
        private RelayCommands _removeCommand;
        public RelayCommands RemoveCommand
        {
            get
            {
               return _removeCommand ??
                   (_removeCommand = new RelayCommands((selectedItem) =>
                   {
                       UnitOfWork unitOfWork = new UnitOfWork();
                       MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                       if (selectedDoctor == null || result == MessageBoxResult.No) return;
                      
                       Doctor doctor = selectedDoctor as Doctor;
                       Doctors.Remove(doctor);
                       unitOfWork.Doctors.Delete(doctor.Id);
                       unitOfWork.Users.Delete(doctor.Id);
                       unitOfWork.Save();
                       OnPropertyChanged("Remove");
                   }));
            }
        }

        //private RelayCommands searchCommand;
        //public RelayCommands SearchCommand
        //{
        //    get
        //    {
        //        return searchCommand ?? (searchCommand = new RelayCommands((selectedItem) =>
        //        {
        //            using (ProjectContext db = new ProjectContext())
        //            {
                       
        //                IQueryable<Doctor> queryable = db.Doctors.Where(p => p.IsArchived == false);
                       
        //                if (!string.IsNullOrWhiteSpace(FirstNames.ToString()))
        //                {
                            
        //                    queryable = queryable.Where(p => p.FirstName.Contains(FirstNames.ToString().Trim()));
        //                }
                    
        //                if (!string.IsNullOrWhiteSpace(LastNames.ToString()))
        //                {
                          
        //                    queryable = queryable.Where(p => p.LastName.Contains(LastNames.ToString().Trim()));
        //                }
                       
        //                if (!string.IsNullOrWhiteSpace(DateOfBirthd.ToString()))
        //                {
                           
        //                    int year = Convert.ToInt32(DateOfBirthd.ToString());
        //                    queryable = queryable.Where(p => p.DateOfBirth.Year == year);
        //                }
                       
        //                if (!string.IsNullOrWhiteSpace(Experiences.ToString()))
        //                {
                          
        //                    queryable = queryable.Where(p => p.Experience.Contains(Experiences.ToString().Trim()));
        //                }

        //                IDoctors = queryable;
        //            }
        //        }));
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged; // отслеживать изменения нашего поля сразу(binding)
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
