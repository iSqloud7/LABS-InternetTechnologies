using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab08.Models
{
    public class Patient
    {
        private List<Doctor> doctors;

        public Patient()
        {
            doctors = new List<Doctor>();
        }
        [Display(Name = "ID на пациент")]
        public int patientID { get; set; }
        [Display(Name = "Име на пациент")]
        [Required(ErrorMessage = "Полето за име на пациентот е задолжително!")]
        public string patient_name { get; set; }
        [Display(Name = "Код на пациент")]
        [Range (10000, 99999, ErrorMessage = "Кодот на пациентот мора да има точно 5 цифри!")]
        public int patient_code { get; set; }
        [Display(Name = "Пол на пациент")]
        public string patient_gender { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}