using BackendFinal.Models;

namespace BackendFinal.ViewModels
{
    public class CategoryVM
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
    }
}
