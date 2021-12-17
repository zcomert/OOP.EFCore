using CsvHelper;
using CsvHelper.Configuration;
using OOP.EFCore.ConsoleApp.DAL;
using OOP.EFCore.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BookCsvImporter
{
    public class BookCsv
    {
        public string Title { get; set; }
        public string Author { get; set; }      // Author -> Fullname
        public string Description { get; set; } // BookDetail -> Description

        public int Year { get; set; }           // BookDetail -> Year
        public string Country { get; set; }     // BookDetail -> Country
        public string Language { get; set; }    // BookDetail -> Language
        public int NumberOfPage { get; set; }   // BookDetail -> NumberOfPage
        public string ImageURL { get; set; }    
        public string Link { get; set; }        // BookDetail -> NumberOfPage

        public override string ToString()
        {
            return $"{Title} " +
                $"\n\t Year: {Year} " +
                $"\n\t Link: {Link}";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine
            };

            using (var reader = new StreamReader(Path.Combine("D:","DataSources","EditedBook","books.csv")))
            using (var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<BookCsv>();
                var context = new BookAppDbContext();
                var listOfBooks = new List<Book>();
                foreach (var item in records)
                {
                    var book = new Book
                    {
                        Title = item.Title,
                        Price = item.NumberOfPage * 125,
                        ImageURL = item.ImageURL,
                        CategoryId = 2,
                        BookDetail = new BookDetail
                        {
                            Description = item.Description,
                            Language = item.Language,
                            Country = item.Country,
                            Year = item.Year,
                            NumberOfPage = item.NumberOfPage,
                            Link = item.Link
                        },

                        BookAuthors = new List<BookAuthor>
                        {
                            new BookAuthor
                            {
                                Author = context.Authors.Where(a => a.FullName.Equals(item.Author)).Any() ?
                                         context.Authors.Where(a => a.FullName.Equals(item.Author)).FirstOrDefault() :
                                         new Author { FullName = item.Author}
                            }
                        }
                    };
                   
                    context.Add(book);
                }
                context.SaveChanges();
            }
        }
    }
}
