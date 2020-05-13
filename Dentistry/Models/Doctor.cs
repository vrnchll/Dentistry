using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class Doctor
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        //[RegularExpression(@"/^[a-zA-Zа-яёА-ЯЁ]+$/u", ErrorMessage = "Недопустимые символы в Имени!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Недопустимая длина имена")]
        [Required(ErrorMessage = "Не указано имени пользователя")]
        public string FirstName { get; set; }
        //[RegularExpression(@"/^([А-ЯЁ]{1}[а-яё]{29})", ErrorMessage = "Недопустимые символы в Фамилии!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Недопустимая длина фамилии")]
        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        public string LastName { get; set; }
        //[RegularExpression(@"/^([А-ЯЁ]{1}[а-яё]{29})", ErrorMessage = "Недопустимые символы в Отчестве!")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Недопустимая длина отчества")]
        [Required(ErrorMessage = "Не указано отчество пользователя")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Не указана дата рождения пользователя")]
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Не выбрана должность")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Не указан стаж работы")]
        //[RegularExpression(@"/(^|\s)[0-2]\d?(\s|$)/", ErrorMessage = "Некорректные данные, проверьте введенное значение стажа")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Не указан телефон пользователя")]
        [RegularExpression(@"^[+]375[0-9]{2}[0-9]{3}[0-9]{2}[0-9]{2}$", ErrorMessage = "Неверный формат телефона,\nВведите данные в формате +375(33)3333333")]
        public string NumberOfPhone { get; set; }

        public string Cabinet { get; set; }
        public bool IsArchived { get; set; }

        public ICollection<Reception> Receptions { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Compoun> Compouns { get; set; }
        public Doctor()
        {
            Receptions = new List<Reception>();
            Services = new List<Service>();
            Compouns = new List<Compoun>();
        }
        public User User { get; set; }

    }
}
