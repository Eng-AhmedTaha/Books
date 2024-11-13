using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Books.ViewModels
{
    public class BookFormViewModel
    {
        public int Id { get; set; }  

        public string Title { get; set; }
        [MaxLength(2500)]

        public string Description { get; set; }
        [MaxLength(150)]

        public string Author { get; set; }


        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
