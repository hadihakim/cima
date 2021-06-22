using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data;
using cima.Model;
using System.Net;

namespace cima.Controllers
{
    
    public class FavoritesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Favorites
        // GET: Movies
        [Authorize(Roles = RoleName.NormalAccount)]
        public async Task<ActionResult> List()
        {
            var favorites = db.Favorites.Where(x => x.userName == User.Identity.Name);
            
                return View("List", await favorites.ToListAsync());


        }


        [Authorize(Roles = RoleName.NormalAccount)]
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