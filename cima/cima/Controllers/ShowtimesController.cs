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

namespace cima.Controllers
{
    public class ShowtimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Showtimes
        public async Task<ActionResult> Index()
        {
            var showtimes = db.Showtimes.Include(s => s.Movie);


            if (User.IsInRole(RoleName.CinemaAccount))
            {
                var showtime = db.Showtimes.Include(s => s.Movie).Where(x => x.Movie.userName == User.Identity.Name);
                return View("List", await showtime.ToListAsync());
            }
            else if (User.IsInRole(RoleName.applicationAdmin))
            {
                
                return View("List", await showtimes.ToListAsync());

            }
            else
            {
                return View("ReadOnlyList", await showtimes.ToListAsync());
            }

        }




        public async Task<ActionResult> Movietime(int id)
        {
            var showtime = db.Showtimes.Include(s => s.Movie).Where(x => x.movieId == id);

            return View("Movielist", await showtime.ToListAsync());


            /*if (User.IsInRole(RoleName.CinemaAccount))
            {
                var showtime = db.Showtimes.Include(s => s.Movie).Where(x => x.Movie.userName == User.Identity.Name);
                return View("List", await showtime.ToListAsync());
            }
            else if (User.IsInRole(RoleName.applicationAdmin))
            {

                return View("List", await showtimes.ToListAsync());

            }
            else
            {
                return View("ReadOnlyList", await showtimes.ToListAsync());
            }*/

        }














        // GET: Showtimes/Details/5
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = await db.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            return View(showtime);
        }

        // GET: Showtimes/Create
        [Authorize(Roles = RoleName.applicationAdmin+","+RoleName.CinemaAccount)]
        public ActionResult Create()
        {
            
            ViewBag.movieId = new SelectList(db.Movies.Where(x => x.userName == User.Identity.Name), "movieid", "movieName");
            
            return View();
        }

        // POST: Showtimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Create([Bind(Include = "showtimeId,movieId,day,time1,time2,time3,time4")] Showtime showtime)
        {
            if (ModelState.IsValid)
            {
               /* var currentUMUser = User.Identity.Name;
                //var currentUser = db.Users.Find(currentUMUser.UserID);
                movie.userName = currentUMUser;*/
                db.Showtimes.Add(showtime);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.movieId = new SelectList(db.Movies, "movieid", "movieName", showtime.movieId);
            return View(showtime);
        }

        // GET: Showtimes/Edit/5
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = await db.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            ViewBag.movieId = new SelectList(db.Movies, "movieid", "movieName", showtime.movieId);
            return View(showtime);
        }

        // POST: Showtimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Edit([Bind(Include = "showtimeId,movieId,day,time1,time2,time3,time4")] Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showtime).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.movieId = new SelectList(db.Movies, "movieid", "movieName", showtime.movieId);
            return View(showtime);
        }

        // GET: Showtimes/Delete/5
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = await db.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            return View(showtime);
        }

        // POST: Showtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.applicationAdmin + "," + RoleName.CinemaAccount)]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Showtime showtime = await db.Showtimes.FindAsync(id);
            db.Showtimes.Remove(showtime);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
