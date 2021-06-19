using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cima.Models;

namespace cima.Controllers
{
    public class testingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: testings
        public async Task<ActionResult> Index()
        {
            return View(await db.testings.ToListAsync());
        }

        // GET: testings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testing testing = await db.testings.FindAsync(id);
            if (testing == null)
            {
                return HttpNotFound();
            }
            return View(testing);
        }

        // GET: testings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: testings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "testId,testname")] testing testing)
        {
            if (ModelState.IsValid)
            {
                db.testings.Add(testing);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testing);
        }

        // GET: testings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testing testing = await db.testings.FindAsync(id);
            if (testing == null)
            {
                return HttpNotFound();
            }
            return View(testing);
        }

        // POST: testings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "testId,testname")] testing testing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testing).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testing);
        }

        // GET: testings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testing testing = await db.testings.FindAsync(id);
            if (testing == null)
            {
                return HttpNotFound();
            }
            return View(testing);
        }

        // POST: testings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            testing testing = await db.testings.FindAsync(id);
            db.testings.Remove(testing);
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
