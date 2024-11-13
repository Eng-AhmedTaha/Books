using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(250)]

        public string Name { get; set; }


        public List<Book> book { get; set; }
    }
}
