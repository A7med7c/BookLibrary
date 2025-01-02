using BookLibrary.BL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BL.View_Model
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
