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
    public class CompanyRepository : Repository<Company>, ICompanyRepository 
        {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Company obj)
        {
            _context.Companies.Update(obj);
        }
    }
}
