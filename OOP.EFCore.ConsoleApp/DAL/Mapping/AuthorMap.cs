using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP.EFCore.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.DAL.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            builder.Property(a => a.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.HasData(
                new Author
                {
                    AuthorId =1,
                    FullName = "Zafer CÖMERT"
                },
                new Author
                {
                    AuthorId=2,
                    FullName = "Ahmet Can"
                },
                new Author
                {
                    AuthorId = 3,
                    FullName ="Fatih Mehmet Çelik"
                }
            );
        }
    }
}
