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
        [Key]
        public int BookId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
