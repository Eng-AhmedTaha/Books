using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(250)]

        public string Title { get; set; }
        [MaxLength(2500)]

        public string Description { get; set; }
        [MaxLength(150)]

        public string Author { get; set; }
        public DateTime Addon { get; set; }
        public Book()
        {
            Addon = DateTime.Now;
        }

        [ForeignKey(nameof(categoryId))]
        public int categoryId { get; set; }


        public Category? category { get; set; }

    }
}
