using System.ComponentModel.DataAnnotations;

namespace BackendFinal.ViewModels
{
    public class BioVM
    {
        public IFormFile Photo { get; set; }
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string WorkingTime { get; set; }
    }
}
