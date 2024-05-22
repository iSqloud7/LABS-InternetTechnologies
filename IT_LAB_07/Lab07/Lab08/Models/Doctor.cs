using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab08.Models
{
    public class Doctor
    {
        private List<Patient> patients;

        public Doctor()
        {
            patients = new List<Patient>();
        }
        [Display(Name = "ID на доктор")]
        public int doctorID { get; set; }
        [Display(Name = "Име на доктор")]
        public string doctor_name { get; set; }
        [Display(Name = "ID на болница")]
        public int hospitalID { get; set; }
        public Hospital hospital { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public int SelectedPatientID { get; set; }
    }
}