using Books.Models;
using Books.ViewModels;

namespace Books.Services
{
    public interface IBooksService
    {
    public    Task Create(BookFormViewModel model);
        Task<Book?> Edit(BookFormViewModel model);
        IEnumerable<Book> GetAll();

        Book? GetById(int id);
        public bool Delete(int id);
    }
}
