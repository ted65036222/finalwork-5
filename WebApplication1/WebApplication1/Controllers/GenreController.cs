using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre

        public ActionResult Index(int? genreID)
        {
            List<Models.Albums> result = new List<Models.Albums>();
            Service.Database2Service db2 = new Service.Database2Service();

            var genres=db2.LoadAllGenre();

            ViewBag.Genres = genres;
            ViewBag.SelectedGenreID = genreID;

            if (genreID != null)
            {
                result = db2.LoadAlbumByGenreID(genreID.Value);
            }
            return  View(result);
        }

    }
}