using BookLibrary.DataAcess.Data;
using BookLibrary.DataAcess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; set; }
        public IApplicationUserRepository ApplicationUser { get; set; }

        public ICompanyRepository Company { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;
            Category = new CategoryRepository(context); 
            Product = new ProductRepository(context);
            ShoppingCart = new ShoppingCartRepository(context);
            ApplicationUser = new ApplicationUserRepository(context);
            Company = new CompanyRepository (context);
            OrderDetail = new OrderDetailRepository(context);
            OrderHeader = new OrderHeaderRepository(context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
