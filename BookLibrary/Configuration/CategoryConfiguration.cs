using BookLibraryWeb.Data;
using BookLibraryWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibraryWeb.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c=>c.CategoryId);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasColumnName("Category Name");
            
            builder.Property(c => c.DisplayOrder).HasColumnName("Display Order");
            
        }
    }
}
