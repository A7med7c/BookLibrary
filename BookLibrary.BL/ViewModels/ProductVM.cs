using BookLibrary.BL.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BL.View_Model
{
    public class ProductVM
    {
        public Product Product { get; set; }
        [Display(Name ="Category Name")]
        public int  CategoryId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoriesList { get; set; }
    }
}
