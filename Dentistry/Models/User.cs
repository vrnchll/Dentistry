using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
   public class User
    {
        public int Id { get; set; }
        public string TypeUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        
        public Patient PatientProfile { get; set; }
        public Doctor DoctorProfile { get; set; }
    }
}
