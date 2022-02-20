using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model.Dto
{
    public class PrescriptionRequest{
        
        [Required(ErrorMessage = "400")]
        public int IdPrescription { get; set; }
    }
}

