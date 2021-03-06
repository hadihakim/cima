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
        [Authorize]
        public async Task<ActionResult> List()
        {
            var favorite = db.Favorites.Where(x => x.userName == User.Identity.Name).ToList();

            
            List<FavoriteMovieViewModel> listfm = new List<FavoriteMovieViewModel>();

            //var test = db.Favorites.Where(x => x.userName == User.Identity.Name).ToList();
            //var tmov = db.Movies.Where(x => x.movieid != -5);

            var lmov = db.Movies.Where(x => x.movieid > 0);


            foreach (Favorite item in favorite)
            {
                lmov = lmov.Where(x => x.movieid != item.movieId);
            }


            foreach (Movie item in lmov)
            {

                var fb = new FavoriteMovieViewModel();
                fb.Movie = item;
                fb.isfav = false;

                listfm.Add(fb);
            }

            foreach (Favorite item in favorite)
            {
                /*var llmov = db.Movies.Where(x => x.movieid > 0);
                llmov = llmov.Where(x => x.movieid == item.movieId);*/

                Movie llmov = db.Movies.Find(item.movieId);

                var fb = new FavoriteMovieViewModel();
                fb.Movie = llmov;
                fb.isfav = true;

                listfm.Add(fb);
            }

            //((IEnumerable<Favorite>)ViewBag.favorite).Where(x => x.userName == User.Identity.Name);
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
                    // movi = movi.Where(x => x.movieid != fav.movieId);

                 }
            List<FavoriteMovieViewModel> orderByResult = (from s in listfm
                                orderby  s.Movie.movieid descending
                                select s).ToList();
            //return View("ReadOnlyList", await movi.ToListAsync());
            return View("ReadOnlyList", orderByResult);

        }



        [Authorize]
        public async Task<ActionResult> CinemaList(string id)
        {
            //return Content(string.Format("str={0}",id));
         
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var favorite = db.Favorites.Where(x => x.userName == User.Identity.Name);

            var movi = db.Movies.Where(x => x.movieid > 0 );

            foreach (Favorite fav in favorite)
            {
                movi = movi.Where(x => x.movieid != fav.movieId);

            }
            // string s = str.Trim().ToLower();
            movi = movi.Where(x => x.userName == id);


            var favoritee = db.Favorites.Where(x => x.userName == User.Identity.Name).Where(x => x.Movie.userName == id).ToList();

            List<FavoriteMovieViewModel> listfm = new List<FavoriteMovieViewModel>();

            //var test = db.Favorites.Where(x => x.userName == User.Identity.Name).ToList();
            //var tmov = db.Movies.Where(x => x.movieid != -5);

            var lmov = db.Movies.Where(x => x.userName == id);


            foreach (Favorite item in favoritee)
            {
                lmov = lmov.Where(x => x.movieid != item.movieId);
            }


            foreach (Movie item in lmov)
            {

                var fb = new FavoriteMovieViewModel();
                fb.Movie = item;
                fb.isfav = false;

                listfm.Add(fb);
            }

            foreach (Favorite item in favoritee)
            {
                /*var llmov = db.Movies.Where(x => x.movieid > 0);
                llmov = llmov.Where(x => x.movieid == item.movieId);*/

                Movie llmov = db.Movies.Find(item.movieId);

                var fb = new FavoriteMovieViewModel();
                fb.Movie = llmov;
                fb.isfav = true;

                listfm.Add(fb);
            }

            List<FavoriteMovieViewModel> orderByResult = (from s in listfm
                                                          orderby s.Movie.movieid descending
                                                          select s).ToList();

            if (User.IsInRole("NormalAccount"))
            {
                return View("CinemaList", orderByResult);
            }
            else
                return View("CinemaListData", await movi.ToListAsync());
                

           



            /*if (User.IsInRole(RoleName.CinemaAccount))

            {
                // User.Identity.GetUserId(); --> get the current user id
                var movie = db.Movies.Where(x => x.userName == User.Identity.Name);

                return View("List", await movie.ToListAsync());

            }
            else if (User.IsInRole(RoleName.applicationAdmin))
            {
                return View("List", await db.Movies.ToListAsync());
            }*/


        }



        // GET: Movies/Details/5
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Detailsc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.FindAsync(id);
            /*if (movie.userName != User.Identity.Name && movie.userName != "admin@gmail.com")
            {
                return HttpNotFound();
            }*/
            if (movie == null)
            {

                return HttpNotFound();
            }
            return View(movie);
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
            /*if (movie.userName != User.Identity.Name && movie.userName != "admin@gmail.com")
            {
                return HttpNotFound();
            }*/
            if (movie == null)
            {

                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles = RoleName.CinemaAccount)]
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CinemaAccount)]
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
        [Authorize(Roles = RoleName.NormalAccount)]
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




        [Authorize(Roles = RoleName.NormalAccount)]
        public async Task<ActionResult> Favcinlist(int id) 
        {
            Favorite ffavorite = new Favorite();
            var currentUMUser = User.Identity.Name;
            ffavorite.userName = currentUMUser;
            var v = db.Movies.Find(id);
            string ss = v.userName;
            try
            {
               
                //var currentUser = db.Users.Find(currentUMUser.UserID);
                
                ffavorite.movieId = id;


                db.Favorites.Add(ffavorite);
                await db.SaveChangesAsync();
                return RedirectToAction("CinemaList", new {id = ss});
            }
            catch (Exception)
            {

                return RedirectToAction("CinemaList", new {id = ss});
            }

        }


        [Authorize(Roles = RoleName.NormalAccount)]
        public async Task<ActionResult> Unfavcinlist(int id)
        {
            var movi = db.Movies.Find(id);
            string ss = movi.userName;


            try
            {

                Favorite fav = await db.Favorites.FindAsync(User.Identity.Name, id);
                db.Favorites.Remove(fav);
                await db.SaveChangesAsync();

                return RedirectToAction("CinemaList", new {id = ss });
            }
            catch (Exception)
            {

                return RedirectToAction("CinemaList", new { id = ss});
            }

        }


        [Authorize(Roles = RoleName.applicationAdmin)]
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


        [Authorize(Roles = RoleName.NormalAccount)]
        public async Task<ActionResult> Unfavoritesm(int id)
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
        [Authorize(Roles = RoleName.CinemaAccount)]
        public async Task<ActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await db.Movies.FindAsync(id);

            if (movie.userName != User.Identity.Name)
            {
                return HttpNotFound();
            }
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
        [Authorize(Roles = RoleName.CinemaAccount)]
        public async Task<ActionResult> Edit([Bind(Include = "movieid,MovieGenre,releaseDate,movieName,movieYear,movieSeason,starring,creator")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.userName = User.Identity.Name;
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

            if (movie.userName != User.Identity.Name && movie.userName != "admin@gmail.com")
            {
                return HttpNotFound();
            }
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
            if (movie.userName != User.Identity.Name && movie.userName != "admin@gmail.com")
            {
                return HttpNotFound();
            }
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
