using Microsoft.AspNetCore.Mvc.Rendering;

namespace Books.Services
{
    public interface IcategoriesServices
    {
        public IEnumerable<SelectListItem> GetSelectList();


    }
}
