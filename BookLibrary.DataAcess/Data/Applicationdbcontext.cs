﻿using BookLibrary.BL.Models;
using BookLibrary.DataAcess.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DataAcess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext():base()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        //DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //insert data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1 , Name = "Action" , DisplayOrder = 1},
                new Category { CategoryId = 2 , Name = "Scifi" , DisplayOrder = 2},
                new Category { CategoryId = 3 , Name = "History" , DisplayOrder = 3}
           );


            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  ProductId = 1,
                  Title = "Fortune of Time",
                  Author = "Billy Spark",
                  Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                  ISBN = "SWD9999001",
                  ListPrice = 99,
                  Price = 90,
                  Price50 = 85,
                  Price100 = 80,
                  CategoryId = 1,
                  ImageUrl = ""
              },
              new Product
              {
                  ProductId = 2,
                  Title = "Dark Skies",
                  Author = "Nancy Hoover",
                  Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                  ISBN = "CAW777777701",
                  ListPrice = 40,
                  Price = 30,
                  Price50 = 25,
                  Price100 = 20,
                  CategoryId = 1,
                  ImageUrl = ""
              },
              new Product
              {
                  ProductId = 3,
                  Title = "Vanish in the Sunset",
                  Author = "Julian Button",
                  Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                  ISBN = "RITO5555501",
                  ListPrice = 55,
                  Price = 50,
                  Price50 = 40,
                  Price100 = 35,
                  CategoryId = 1,
                  ImageUrl = ""
              },
              new Product
              {
                  ProductId = 4,
                  Title = "Cotton Candy",
                  Author = "Abby Muscles",
                  Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                  ISBN = "WS3333333301",
                  ListPrice = 70,
                  Price = 65,
                  Price50 = 60,
                  Price100 = 55,
                  CategoryId = 2,
                  ImageUrl = ""
              },
              new Product
              {
                  ProductId = 5,
                  Title = "Rock in the Ocean",
                  Author = "Ron Parker",
                  Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                  ISBN = "SOTJ1111111101",
                  ListPrice = 30,
                  Price = 27,
                  Price50 = 25,
                  Price100 = 20,
                  CategoryId = 2,
                  ImageUrl = ""
              },
              new Product
              {
                  ProductId = 6,
                  Title = "Leaves and Wonders",
                  Author = "Laura Phantom",
                  Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                  ISBN = "FOT000000001",
                  ListPrice = 25,
                  Price = 23,
                  Price50 = 22,
                  Price100 = 20,
                  CategoryId = 3,
                  ImageUrl = ""
              }
                );
            //ApplyConfiguration
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

      
        }
    }
}
