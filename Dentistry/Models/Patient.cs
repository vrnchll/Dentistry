using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class Patient
    {
        [Index]
        [Key]
       
        public int Id { get; set; }
        public string FirstName { get; set; }
  
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set;}
        public int House { get; set; }
        public int Flat { get; set; }
        public int NumberOfPhone { get; set; }

        
        public User User { get; set; }


        public virtual ICollection<Compoun> Compouns { get; set;}
        public virtual ICollection<Reception> Receptions { get; set; }
        public Patient()
        {
            Compouns = new List<Compoun>();
            Receptions = new List<Reception>();
        }
    }
}
