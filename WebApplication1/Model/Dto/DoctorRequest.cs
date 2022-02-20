using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Model.Dto
{
    public class DoctorRequest
    {

        [Required(ErrorMessage = "400")]
        public int IdDoctor { get; set; }
        [Required(ErrorMessage = "400")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "400")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "400")]
        public string Email { get; set; }

    }
}
