using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
   public  class Services
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

       public ICollection<Doctor> Doctors { get; set; } 
        public Services()
        {
            Doctors = new List<Doctor>();
        }

      
    }
}
