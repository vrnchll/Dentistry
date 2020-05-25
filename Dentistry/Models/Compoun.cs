using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class Compoun
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Не выбрана дата")]
        public string DateOfReception { get; set; }
        //[Required(ErrorMessage = "Не выбрано время")]
        public string TimeOfReception { get; set; }

        public string Status { get; set; }
       
   
        public bool IsOrder { get; set; }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
      
    }
}
