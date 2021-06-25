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
    
    public class MoviesFeedBacksViewModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: MoviesFeedBacksViewModel
        public ActionResult View()
        {
            MoviesFeedBacksViewModelController x = new MoviesFeedBacksViewModelController();
            return View(x);
        }


        public async Task<ActionResult> New(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieFeedBackViewModel moviefeed = new MovieFeedBackViewModel();
            var movie = await db.Movies.FindAsync(id);
            var release = movie.releaseDate;
            var moviename = movie.movieName;
            moviefeed.releaseDate = release;
            moviefeed.movieName = moviename;

            var movieyear = movie.movieYear;
            moviefeed.movieYear = movieyear;

            var movieid = movie.movieid;
            moviefeed.movieId = movieid;

            var username = movie.userName;
            moviefeed.userName = username;

            var movieseason = movie.movieSeason;
            moviefeed.movieSeason = movieseason;

            var moviestarring = movie.starring;
            moviefeed.starring = moviestarring;

            var moviecreator = movie.creator;
            moviefeed.creator = moviecreator;


            if (moviefeed == null)
            {

                return HttpNotFound();
            }
            return View(moviefeed);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> New([Bind(Include = "comment, movieId, userName, releaseDate, movieName, movieYear, movieSeason, creator, starring")] MovieFeedBackViewModel moviefeed)
        {
            
            
                FeedBack feed = new FeedBack();
                //var currentUMUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var currentUMUser = User.Identity.Name;

                feed.movieId = moviefeed.movieId;
                feed.userName = currentUMUser;
                feed.comment = moviefeed.comment;

            //var currentUser = db.Users.Find(currentUMUser.UserID);
            if (moviefeed.comment.Length > 500)
            {
                return View(moviefeed);


            }

            db.FeedBacks.Add(feed);
                await db.SaveChangesAsync();
                if (moviefeed.creator.Length >500)
                {
                    return View(moviefeed);


                }
                return RedirectToAction("Index", "FeedBacks");
            
          
        }


        // GET: MoviesFeedBacksViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MoviesFeedBacksViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesFeedBacksViewModel/Create
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

        // GET: MoviesFeedBacksViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoviesFeedBacksViewModel/Edit/5
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

        // GET: MoviesFeedBacksViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MoviesFeedBacksViewModel/Delete/5
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
