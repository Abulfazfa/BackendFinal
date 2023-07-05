using System.ComponentModel.DataAnnotations;

namespace BackendFinal.Models
{
    public class Category : BaseEntity
    {      
        [Required]
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Category? Parent { get; set; }
        public IEnumerable<Category>? Children { get; set; }

        public Category()
        {
            IsDeleted = false;
        }

    }
}
