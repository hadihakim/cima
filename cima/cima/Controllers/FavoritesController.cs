﻿using System;
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
        public async Task<ActionResult> List()
        {
            var favorites = db.Favorites.Where(x => x.userName == User.Identity.Name);
            
                return View("List", await favorites.ToListAsync());


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