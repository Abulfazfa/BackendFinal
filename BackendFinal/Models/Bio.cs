using System.ComponentModel.DataAnnotations;

namespace BackendFinal.Models
{
    public class Bio
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; }
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string WorkingTime { get; set; }
        public string GeneralInformation { get; set; }
        public string AboutImgUrl { get; set; }
       


    }
}
