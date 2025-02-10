using BookLibrary.BL.Models;
using BookLibrary.DataAcess.Data;
using BookLibrary.DataAcess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAcess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;   
        }
        public void Update(ApplicationUser obj)
        {
            _context.ApplicationUsers.Update(obj);  
        }
    }
}
