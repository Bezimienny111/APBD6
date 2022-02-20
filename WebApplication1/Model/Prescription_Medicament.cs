using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class Prescription_Medicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }
        [ForeignKey("IdPrescription")]
        public virtual Prescription Prescription { get; set; }
        [ForeignKey("IdMedicament")]
        public virtual Medicament Medicament { get; set; }
    }
}