using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab08.Models
{
    public class Hospital
    {
        [Display(Name = "ID на болница")]
        public int hospitalID { get; set; }
        [Display(Name = "Име на болница")]
        public string hospital_name { get; set; }
        [Display(Name = "Адреса на болница")]
        public string hospital_address { get; set; }
        [Display(Name = "Изглед на болница")]
        public string hospital_image { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}