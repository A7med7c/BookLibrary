using BookLibrary.BL.Models;
using BookLibrary.DataAcess.Data;
using BookLibrary.DataAcess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAcess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public List<Product> productsWithCategory()
        {
            var products = _context
                .Products.Include(p => p.Category)
                .ToList();
            return products;
        }

        public void Update(Product obj)
        {
            var objFromDb = _context.Products.FirstOrDefault(e => e.ProductId == obj.ProductId);
            if (objFromDb != null)
            {
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Author = obj.Author;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Title = obj.Title;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }

    }
}
