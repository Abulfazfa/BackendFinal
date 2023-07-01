using System.ComponentModel.DataAnnotations;

namespace BackendFinal.ViewModels
{
    public class ForgetPasswordVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
