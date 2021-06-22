using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cima.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;


namespace cima.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public async Task<ActionResult> List()
        {
            var favorite = db.Favorites.Where(x => x.userName == User.Identity.Name);

            var movi = db.Movies.Where(x => x.movieid > 0);

            if (User.IsInRole(RoleName.CinemaAccount))

            {
                // User.Identity.GetUserId(); --> get the current user id
                var movie = db.Movies.Where(x => x.userName == User.Identity.Name);

                return View("List", await movie.ToListAsync());

            }
            else if (User.IsInRole(RoleName.applicationAdmin))
            {
                return View("List", await db.Movies.ToListAsync());
            }
            else
                foreach (Favorite fav in favorite) {
                    movi = movi.Where(x => x.movieid != fav.movieId);

                }

            return View("ReadOnlyList", await movi.ToListAsync());

        }

        // GET: Movies/Details/5
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {

                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles = RoleName.applicationAdmin+","+RoleName.CinemaAccount)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Create([Bind(Include = "movieid,MovieGenre,releaseDate,movieName,movieYear,movieSeason,starring,creator")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //var currentUMUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var currentUMUser = User.Identity.Name;
                //var currentUser = db.Users.Find(currentUMUser.UserID);
                movie.userName = currentUMUser; 
                db.Movies.Add(movie);
                await db.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return View(movie);
        }




        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        public async Task<ActionResult> Favorites(int id)  
        {
            try
            {
                Favorite ffavorite = new Favorite();

                var currentUMUser = User.Identity.Name;
                //var currentUser = db.Users.Find(currentUMUser.UserID);
                ffavorite.userName = currentUMUser;
                ffavorite.movieId = id;


                db.Favorites.Add(ffavorite);
                await db.SaveChangesAsync();
                return RedirectToAction("List");
            }
            catch (Exception)
            {

                return RedirectToAction("List");
            }

        }

        [Authorize]
        public async Task<ActionResult> Unfavorites(int id)
        {

            try
            {

                Favorite fav = await db.Favorites.FindAsync(User.Identity.Name, id);
                db.Favorites.Remove(fav);
                await db.SaveChangesAsync();

                return RedirectToAction("List");
            }
            catch (Exception)
            {

                return RedirectToAction("List");
            }

        }








        // GET: Movies/Edit/5
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Edit([Bind(Include = "movieid,MovieGenre,releaseDate,movieName,movieYear,movieSeason,starring,creator")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return HttpNotFound();
                
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }





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
