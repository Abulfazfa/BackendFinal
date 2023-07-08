using System.ComponentModel.DataAnnotations;

namespace BackendFinal.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImgUrl { get; set; }
        public string Date { get; set; }
        public string CreatedDate { get; set; }
    }
}
