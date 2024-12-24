using System.ComponentModel.DataAnnotations;

namespace BookLibraryWeb.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

    }
}
