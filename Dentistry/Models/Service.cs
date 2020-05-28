using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
   public  class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано наименование услуги")]
    
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Недопустимая длина наименования услуги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана стоимость")]
  
        public string Cost { get; set; }

      
        public ICollection<Reception> Receptions { get; set; }
        public ICollection<Doctor> Doctors { get; set; } 
        public Service()
        {
            Doctors = new List<Doctor>();
            Receptions = new List<Reception>();
        }

      
    }
}
