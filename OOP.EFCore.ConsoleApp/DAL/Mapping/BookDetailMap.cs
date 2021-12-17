using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP.EFCore.ConsoleApp.Entities;
using System;

namespace OOP.EFCore.ConsoleApp.DAL.Mapping
{
    public class BookDetailMap : IEntityTypeConfiguration<BookDetail>
    {
        public void Configure(EntityTypeBuilder<BookDetail> builder)
        {
            builder.HasKey(bd => bd.BookDetailId);

            builder.Property(bd => bd.ISSN)
                .IsRequired()
                .HasDefaultValue("0000-0000-0000");

            builder.Property(bd => bd.Year)
                .HasDefaultValue(DateTime.Now.Year);

            builder.HasOne(bd => bd.Book)
                .WithOne(b => b.BookDetail)
                .HasForeignKey<BookDetail>(bd => bd.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new BookDetail
                {
                    BookDetailId=1,
                    BookId=1,
                    Description="Yazılım Evi",
                    Year = 2021,
                    Language="Turkish",
                    Country="Turkey",
                    NumberOfPage=35,
                    Link = "https://www.youtube.com/channel/UCFkGSddGBO-f4gw1otESNqQ"
                },
                new BookDetail
                {
                    BookDetailId = 2,
                    BookId = 2,
                    Description = "Nesne yönelimli programlama",
                    Year = 2021,
                    Language = "Turkish",
                    Country = "Turkey",
                    NumberOfPage = 35,
                    Link = "https://www.youtube.com/watch?v=fjuSAN4HTqQ&list=PLK37qYAhi0Ec8_8aX3RKHjzZvRNr-mAl3"
                },
                new BookDetail
                {
                    BookDetailId = 3,
                    BookId = 3,
                    Description = "Yazılım Gereksinimi ve Modelleme",
                    Year = 2021,
                    Language = "Turkish",
                    Country = "Turkey",
                    NumberOfPage = 35,
                    Link = "https://www.youtube.com/watch?v=VK49Ov5i8GQ&list=PLK37qYAhi0Efy7-vlU8QSjB_nc6qPf8sJ"
                }
            );
        }
    }
}
