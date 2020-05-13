﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class Reception
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не выбрано время начала")]
        public string DateOfBeginReception { get; set; }
        [Required(ErrorMessage = "Не выбрано время окончания")]
        public string DateOfEndReception { get; set; }

        //?
        public virtual ICollection<Service> Services { get; set; }
        public Reception()
        {
            Services = new List<Service>();
        }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
