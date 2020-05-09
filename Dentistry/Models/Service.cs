using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
   public  class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }

       public ICollection<Doctor> Doctors { get; set; } 
        public Service()
        {
            Doctors = new List<Doctor>();
        }

      
    }
}
