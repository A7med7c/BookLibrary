using BookLibrary.BL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAcess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.Title).IsRequired();

            builder.Property(x=>x.ISBN).IsRequired();

            builder.Property(x=>x.Author).IsRequired(); 

            builder.Property(x=>x.ListPrice).IsRequired();

            builder.Property(x=>x.Price).IsRequired();

            builder.Property(x=>x.Price50).IsRequired();

            builder.Property(x=>x.Price100).IsRequired();

            

        }
    }
}
