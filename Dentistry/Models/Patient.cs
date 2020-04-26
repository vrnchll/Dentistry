using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
  
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set;}
        public string House { get; set; }
        public string Flat { get; set; }
        public int NumberOfPhone { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }


        public virtual ICollection<Compoun> Compouns { get; set;}
        public virtual ICollection<Reception> Receptions { get; set; }
        public Patient()
        {
            Compouns = new List<Compoun>();
            Receptions = new List<Reception>();
        }
    }
}
