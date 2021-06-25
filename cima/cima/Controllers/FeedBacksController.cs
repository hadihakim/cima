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
    public class FeedBacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FeedBacks
        public async Task<ActionResult> Index()
        {
            var feedBacks = db.FeedBacks.Include(f => f.Movie);
            return View(await feedBacks.ToListAsync());
        }


        public async Task<ActionResult> New(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Movie = db.Movies.Where(x => x.movieid == id);
            Movie movie = await db.Movies.FindAsync(id);
            
            if (movie == null)
            {

                return HttpNotFound();
            }
            return View();
        }












        // GET: FeedBacks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = await db.FeedBacks.FindAsync(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // GET: FeedBacks/Create
        public ActionResult Create()
        {
            ViewBag.movieId = new SelectList(db.Movies, "movieid", "movieName");
            return View();
        }

        // POST: FeedBacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "feedBackId,movieId,comment,userName")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.FeedBacks.Add(feedBack);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.movieId = new SelectList(db.Movies, "movieid", "movieName", feedBack.movieId);
            return View(feedBack);
        }

        // GET: FeedBacks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = await db.FeedBacks.FindAsync(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            ViewBag.movieId = new SelectList(db.Movies, "movieid", "movieName", feedBack.movieId);
            return View(feedBack);
        }

        // POST: FeedBacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "feedBackId,movieId,comment,userName")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedBack).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.movieId = new SelectList(db.Movies, "movieid", "movieName", feedBack.movieId);
            return View(feedBack);
        }

        // GET: FeedBacks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = await db.FeedBacks.FindAsync(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // POST: FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FeedBack feedBack = await db.FeedBacks.FindAsync(id);
            db.FeedBacks.Remove(feedBack);
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
