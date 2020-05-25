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
  
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
     
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Недопустимая длина имени")]
         [Required(ErrorMessage = "Не указано имя пользователя")]

        [RegularExpression(@"/^[А-Я]{1}[а-я]{1,20}$/", ErrorMessage = "Недопустимые символы в Имени!")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "Недопустимая длина фамилии")]
        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        [RegularExpression(@"/^[А-Я]{1}[а-я]{1,20}$/", ErrorMessage = "Недопустимые символы в Фамилии!")]
        public string LastName { get; set; }
    
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Недопустимая длина отчества")]
        [Required(ErrorMessage = "Не указано отчество пользователя")]
        [RegularExpression(@"/^[А-Я]{1}[а-я]{1,20}$/", ErrorMessage = "Недопустимые символы в Отчестве!")]

        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Не указана дата рождения пользователя")]
        [RegularExpression(@"([0-2]\d|3[01])\.(0\d|1[012])\.(\d{4})", ErrorMessage = "Неверный формат даты")]

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }
        [Required(ErrorMessage = "Не указан город")]
        public string City { get; set; }
        [Required(ErrorMessage = "Не указана улица")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Недопустимое значение")]
        [RegularExpression(@"/^[А-Я]{1}[а-я]{1,25}$/", ErrorMessage = "Недопустимые символы в названии улицы!")]
        public string Street { get; set;}

        [Required(ErrorMessage = "Не указан дом")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Недопустимое значение")]
        public string House { get; set; }

        [StringLength(3, MinimumLength = 1, ErrorMessage = "Недопустимое значение")]
        public string Flat { get; set; }
        [Required(ErrorMessage = "Не указан телефон пользователя")]
        [RegularExpression(@"^[+]375[0-9]{2}[0-9]{3}[0-9]{2}[0-9]{2}$", ErrorMessage = "Неверный формат телефона,\nВведите данные в формате +375(33)333-33-33")]

        public string NumberOfPhone { get; set; }
        
        
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
