using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }

        public DateTime CreatedDate { get; set; }

        // collection navigation property
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
