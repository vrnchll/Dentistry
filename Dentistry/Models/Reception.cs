using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class Reception
    {
        public int Id { get; set; }

        public DateTime DateOfBeginReception { get; set; }
        public DateTime DateOfEndReception { get; set; }

        //?
        public virtual ICollection<Services> Services { get; set; }
        public Reception()
        {
            Services = new List<Services>();
        }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
