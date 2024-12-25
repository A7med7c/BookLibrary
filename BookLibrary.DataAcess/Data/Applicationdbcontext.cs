using BookLibrary.BL.Models;
using BookLibrary.DataAcess.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DataAcess.Data
{
    public class ApplicationDbContext : DbContext            
    {
        public ApplicationDbContext():base()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        //DbSets
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //insert data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1 , Name = "Action" , DisplayOrder = 1},
                new Category { CategoryId = 2 , Name = "Scifi" , DisplayOrder = 2},
                new Category { CategoryId = 3 , Name = "History" , DisplayOrder = 3}
           );
            
            //ApplyConfiguration
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        
        }
    }
}
