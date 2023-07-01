using BackendFinal.Models;

namespace BackendFinal.ViewModels
{
    public class AboutVM
    {
        public string Photo { get; set; }
        public string GeneralInformation { get; set; }
        public List<AboutSection> Sections { get; set; }

    }
}
