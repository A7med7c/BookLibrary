using System.ComponentModel.DataAnnotations;

namespace BookLibrary.BL.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "DisplayOrder must be between 1 and 100.")]
        public int DisplayOrder { get; set; }

        public List<Product> Products { get; set; }


    }
}
