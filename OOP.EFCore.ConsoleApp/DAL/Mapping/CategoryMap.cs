using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP.EFCore.ConsoleApp.Entities;

namespace OOP.EFCore.ConsoleApp.DAL.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Description)
                .HasDefaultValue("No info.");

            builder.HasData(
                new Category { CategoryId = 1, CategoryName = "Health" },
                new Category { CategoryId = 2, CategoryName = "Computer Science" },
                new Category { CategoryId = 3, CategoryName = "Novel" }
            );
        }
    }
}
