using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class Doctor
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }
        public int NumberOfPhone { get; set; }

        public int Cabinet { get; set; }

        public ICollection<Reception> Receptions { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Compoun> Compouns { get; set; }
        public Doctor()
        {
            Receptions = new List<Reception>();
            Services = new List<Service>();
            Compouns = new List<Compoun>();
        }
        public User User { get; set; }

    }
}
