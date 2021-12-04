using Microsoft.EntityFrameworkCore;
using OOP.EFCore.ConsoleApp.DAL.Mapping;
using OOP.EFCore.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.DAL
{
    public class BookAppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder 
            optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BookAppDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMap());
        }
    }
}
