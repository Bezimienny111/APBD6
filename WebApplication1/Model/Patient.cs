using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Patient
    {
        public Patient()
        {
            Prescription = new HashSet<Prescription>();
        }
        [Key]
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }

    }
}