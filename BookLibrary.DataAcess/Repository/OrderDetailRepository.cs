using BookLibrary.BL.Models;
using BookLibrary.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAcess.Repository.IRepository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



        public void Update(OrderDetail obj)
        {
            _context.OrderDetails.Update(obj);
        }
    }
}
