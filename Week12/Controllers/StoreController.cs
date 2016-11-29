using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week12.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            // connect to the db
            using (Models.DefaultConnection db = new Models.DefaultConnection())
            {
                // use the Genre model to get all the genres
                var genres = db.Genres.ToList();

                // create a list sorted by Name and pass that instead of the original list
                var genresAz = from g in genres
                               orderby g.Name ascending
                               select g;

                // load the view and pass it the query results
                return View(genresAz);
            }

        }

        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            //try { 
            // connect to the db and query for the right data
            using (Models.DefaultConnection db = new Models.DefaultConnection())
            {
                // get the selected genre and the related albums
                var genreData = db.Genres.Include("Albums")
                    .SingleOrDefault(g => g.Name == genre);

                if (genreData == null)
                {
                    return RedirectToAction("Index"); 
                    //return View("Index");
                }
                else { 
                    // load the view
                    return View(genreData);
                }
            }

        }

        // GET: /Store/Details
        public String Details(int id)
        {
            string message = "Store.Details, ID = " + id;
            return message;
        }
    }
}