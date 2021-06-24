using cima.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cima.Controllers
{
    public class MostFavoriteViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: MostFavoriteViewModel
        [Authorize]
        public ActionResult Mostfavorite()
        {

            var favorites = (from c in db.Favorites
                             group c by new { c.Movie.movieName, c.Movie.userName } into grouping
                            
                             select new MostFavoriteViewModel
                             
                             

                             {
                                 MovieName = grouping.Key.movieName,
                                 userName = grouping.Key.userName,
                                 Count = grouping.Count()

                             }).ToList();
             


            return View("Mostfavorite", favorites.OrderByDescending(x => x.Count));


        }

        // GET: MostFavoriteViewModel/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MostFavoriteViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MostFavoriteViewModel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MostFavoriteViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MostFavoriteViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MostFavoriteViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MostFavoriteViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
