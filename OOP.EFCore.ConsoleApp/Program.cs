using OOP.EFCore.ConsoleApp.DAL;
using OOP.EFCore.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP.EFCore.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new BookAppDbContext();
            //Console.WriteLine(context.Authors.Where(a => a.FullName.Contains("Homer")).Count());
            Console.ReadKey();
        }

        private static void AddBookWithCategoryAndDetails()
        {
            using (var _context = new BookAppDbContext())
            {
                var book = new Book
                {
                    Title = "Database Management",
                    Price = 400,
                    Category = _context
                                .Categories
                                .OrderBy(c => c.CategoryId)
                                .FirstOrDefault(),
                    BookDetail = new BookDetail
                    {
                        Country = "Turkey",
                        ISSN = "123-456-789"
                    }
                };
                _context.Books.Add(book);
                _context.SaveChanges();

                ListOfBooks();
            }
        }

        private static void AddBookWithCategory()
        {
            var book = new Book
            {
                Title = "Software Engineering",
                Price = 550,
                Category = new Category
                {
                    CategoryName = "Software"
                }
            };

            using (var _context = new BookAppDbContext())
            {
                _context.Books.Add(book);
                _context.SaveChanges();

                ListOfBooks();

                Console.WriteLine(new String('-', 15));
                _context.Categories
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.CategoryName));
            }
        }

        private static void DeleteBook()
        {
            using (var _context = new BookAppDbContext())
            {
                var book = _context
                    .Books
                    .OrderBy(b => b.BookId)
                    .LastOrDefault();

                _context.Books.Remove(book);
                _context.SaveChanges();
                ListOfBooks();
            }
        }

        private static void UpdateBook()
        {
            using (var _context = new BookAppDbContext())
            {
                var book = _context
                    .Books
                    .OrderBy(b => b.BookId)
                    .FirstOrDefault();

                book.Title = "Updated book";
                book.Price = 10;

                _context.SaveChanges();

                ListOfBooks();
            }
        }

        private static void ListOfBooks()
        {
            var list = new List<Book>();
            using (var _context = new BookAppDbContext())
            {
                list = _context.Books.ToList();
                foreach (var b in list)
                {
                    Console.WriteLine($"{b.BookId,-5} " +
                        $"{b.Title,-45}" +
                        $"{b.Price,-5}");
                }
            }
        }

        private static void AddBooks()
        {
            var list = new List<Book> {
                new Book { Title = "EF Core 1", Price =25},
                new Book { Title = "EF Core 2", Price =125},
                new Book { Title = "EF Core 3", Price =225},
                new Book { Title = "EF Core 4", Price =325},
                new Book { Title = "EF Core 5", Price =425}
            };
            using (var _context = new BookAppDbContext())
            {
                _context.Books.AddRange(list);
                _context.SaveChanges();
            }
        }

        private static void AddBook()
        {
            var book = new Book
            {
                Title = "Entity Framework Core",
                Price = 105
            };

            using (var _context = new BookAppDbContext())
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
        }

    }
}
