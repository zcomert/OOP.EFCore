using System.Collections.Generic;

namespace OOP.EFCore.ConsoleApp.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        // Collection navigation property
        public ICollection<Book> Books { get; set; }
    }
}
