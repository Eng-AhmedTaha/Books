using Books.Data;
using Books.Services;
using Books.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        readonly ApplicationDbContext _context;
        private readonly IBooksService _ibooksservices;
        private readonly IcategoriesServices _icategoriesServices;
        public BooksController(IBooksService ibooksservices, IcategoriesServices icategoriesServices, ApplicationDbContext context)
        {
            _ibooksservices = ibooksservices;
            _icategoriesServices = icategoriesServices;
            _context = context;
        }

        public IActionResult Index()
        {
           var x = _ibooksservices.GetAll();
            return View(x);
        }

        public IActionResult Create()
        {
            BookFormViewModel model = new()
            {
                Categories = _icategoriesServices.GetSelectList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _icategoriesServices.GetSelectList();
                return View(model);
            }

            await _ibooksservices.Create(model);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var v = _ibooksservices.GetById(id);

            return View(v);
        }
        public IActionResult Delete(int id)
        {

            _ibooksservices.Delete(id);

            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var game = _ibooksservices.GetById(id);
            if (game is null)
                return NotFound();

            BookFormViewModel viewModel = new()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Author = game.Author, 
                CategoryId = game.categoryId,
                Categories = _icategoriesServices.GetSelectList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _icategoriesServices.GetSelectList();
                return View(model);
            }

            var updatedBook = await _ibooksservices.Edit(model);
            if (updatedBook is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

    }


}


  