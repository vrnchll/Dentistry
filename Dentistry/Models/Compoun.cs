using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    class Compoun
    {
        public int Id { get; set; }

        public DateTime DateOfReception { get; set; }

        //?
        public virtual ICollection<Services> Services { get; set; }
        public Compoun()
        {
            Services = new List<Services>();
        }



        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public int? DoctorCabinet { get; set; }
        public Doctor Doctor { get; set; }
    }
}
