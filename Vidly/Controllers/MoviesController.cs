using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random

        AppDbContext _context = new AppDbContext();

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = _context.Movies.Include(m => m.MovieGenre);
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(c => c.MovieGenre).SingleOrDefault(x => x.Id == id);


            if (movie == null)
                return HttpNotFound();

            else
            {
                return View(movie);
            }
        }



    }
}