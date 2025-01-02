using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BL.Models
{
    public class Product
    {
        public int ProductId { get; set; }


        public string Title { get; set; }


        public string Description { get; set; }


        public string Author { get; set; }


        public string ISBN { get; set; }

       
        [Display( Name = "List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }

        
        [Display(Name = "List Price 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

      
        [Display(Name = "List Price 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }


        [Display(Name = "List Price 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
    }
}
