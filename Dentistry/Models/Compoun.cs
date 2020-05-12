using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class Compoun
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не выбрана дата")]
        public DateTime DateOfReception { get; set; }

        
        public virtual ICollection<Service> Services { get; set; }
        public Compoun()
        {
            Services = new List<Service>();
        }
   


        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
