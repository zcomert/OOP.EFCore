using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        // foreign key
        public int? CategoryId { get; set; } 
        
        // simple navigation property
        public Category Category { get; set; } 
    }
}
