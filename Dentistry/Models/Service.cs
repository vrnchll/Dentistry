using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
   public  class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано наименование услуги")]
        //[RegularExpression(@"/^[a-zA-Zа-яёА-ЯЁ]+$/u", ErrorMessage = "Недопустимые символы в наименовании!")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Недопустимая длина наименования услуги")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана стоимость")]
        //[RegularExpression(@"/^\d+$/", ErrorMessage = "Недопустимые символы в стоимости!")]
        public string Cost { get; set; }

       public ICollection<Doctor> Doctors { get; set; } 
        public Service()
        {
            Doctors = new List<Doctor>();
        }

      
    }
}
