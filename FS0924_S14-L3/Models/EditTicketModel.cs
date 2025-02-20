using System.ComponentModel.DataAnnotations;

namespace FS0924_S14_L3.Models
{
    public class EditTicketModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, ErrorMessage = "max 20 chars", MinimumLength = 2)]
        public string? Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is required!")]
        [StringLength(20, ErrorMessage = "max 20 chars", MinimumLength = 2)]
        public string? Surname { get; set; }

        [Display(Name = "Hall")]
        [Required(ErrorMessage = "Hall is required!")]
        [StringLength(200, ErrorMessage = "max 20 chars", MinimumLength = 1)]
        public string? Hall { get; set; }

        [Display(Name = "Reduced ticket")]
        public bool? IsReduced { get; set; } = false;

        public string? IsReducedStr { get; set; } = "";
    }
}
