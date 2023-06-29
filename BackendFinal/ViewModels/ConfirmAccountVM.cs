using System.ComponentModel.DataAnnotations;

namespace BackendFinal.ViewModels
{
    public class ConfirmAccountVM
    {
        public string Email { get; set; }
        [Required]
        public string OTP { get; set; }
    }
}
