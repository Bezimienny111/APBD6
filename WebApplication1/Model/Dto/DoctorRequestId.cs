using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.Dto
{
    public class DoctorRequestId
    {
        [Required(ErrorMessage = "400")]
        public int IdDoctor { get; set; }
    }
}
