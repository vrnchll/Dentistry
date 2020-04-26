using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }
        public int NumberOfPhone { get; set; }

        public int Cabinet { get; set; }

        public ICollection<Reception> Receptions { get; set; }
        public ICollection<Services> Services { get; set; }
        public ICollection<Compoun> Compouns { get; set; }
        public Doctor()
        {
            Receptions = new List<Reception>();
            Services = new List<Services>();
            Compouns = new List<Compoun>();
        }

      
    }
}
