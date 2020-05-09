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
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Недопустимая длина имена")]
        [Required(ErrorMessage = "Не указано имени пользователя")]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Недопустимая длина фамилии")]
        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        public string LastName { get; set; }
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Недопустимая длина отчества")]
        [Required(ErrorMessage = "Не указано отчество пользователя")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Не указана дата рождения пользователя")]
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set;}
        public string House { get; set; }
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
