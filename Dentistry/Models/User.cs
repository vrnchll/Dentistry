using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
   public class User
    {
        [Index]
        public int Id { get; set; }
        public string TypeUser { get; set; }
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Недопустимая длина логина")]
        [Required(ErrorMessage = "Не указано логин пользователя")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Не указано пароль")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Недопустимая длина пароля")]
        public string Password { get; set; }
       
        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+", ErrorMessage = "Неверный формат почты")]
        [Required(ErrorMessage = "Не указана почта")]
        public string Email { get; set; }

        
        public Patient PatientProfile { get; set; }
        public Doctor DoctorProfile { get; set; }
    }
}
