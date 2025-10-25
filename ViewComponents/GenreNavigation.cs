using dailyphongve.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace vesStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IdailyphongveRepository repository;
        public GenreNavigation(IdailyphongveRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.ves
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}