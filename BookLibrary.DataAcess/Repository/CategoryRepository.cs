using BookLibrary.BL.Models;
using BookLibrary.DataAcess.Data;
using BookLibrary.DataAcess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAcess.Repository
{
    public class CategoryRepository : Repository<Category> ,ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            
               _context = context;
            
        }
      
        public void Update(Category obj)
        {
            _context.Categories.Update(obj);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
