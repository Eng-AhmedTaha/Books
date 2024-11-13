using Books.Data;
using Books.Models;
using Books.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Books.Services
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext _context;
        public BooksService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(BookFormViewModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                Author = model.Author,
                categoryId = model.CategoryId,
                Addon = DateTime.Now // ضبط تاريخ الإضافة
            };
            _context.books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book?> Edit(BookFormViewModel model)
        {
            var book = await _context.books.FirstOrDefaultAsync(g => g.Id == model.Id);

            if (book == null)
                return null;

            book.Title = model.Title;
            book.Author = model.Author;
            book.Description = model.Description;
            book.categoryId = model.CategoryId;
            book.Addon = DateTime.Now;
            book.Id = model.Id;
           
            await _context.SaveChangesAsync();

            return book;
        }

        public bool Delete(int id)
        {
            try
            {
                var book = _context.books.Find(id);
                if (book == null)
                {
                    return false;
                }

                _context.books.Remove(book);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    
        public IEnumerable<Book> GetAll()
        {
       return     _context.books.AsNoTracking().Include(g => g.category)

                .ToList();

        }

        public Book? GetById(int id)
        {
          return  _context.books.AsNoTracking().Include(g => g.category)
                        .SingleOrDefault(g => g.Id == id);


        }
    }
}
