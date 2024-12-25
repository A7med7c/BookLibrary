using System.ComponentModel.DataAnnotations;

namespace BookLibraryWeb.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "DisplayOrder must be between 1 and 100.")]
        public int DisplayOrder { get; set; }

    }
}
