using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cima.Model;
using cima.Dtos;
using AutoMapper;

namespace cima.Controllers.Api
{
    public class FavoritesController : ApiController
    {
        private ApplicationDbContext db;

        public FavoritesController()
        {
            db = new ApplicationDbContext();
        }
        // DELETE /api/favorites/1
        [HttpDelete]
        public void DeleteFavorite(int id)
        {
            var favoriteInDb = db.Favorites.SingleOrDefault(c => c.movieId == id && c.userName == User.Identity.Name);

            if (favoriteInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Favorites.Remove(favoriteInDb);
            db.SaveChanges();
        }


        [HttpPost]
        public void CreateFavorite(int id)
        {
            var found = db.Favorites.Where(c => c.movieId == id && c.userName == User.Identity.Name).SingleOrDefault();
            /* if (!ModelState.IsValid)
                 return BadRequest();*/

            var FavoriteDto = new FavoriteDto();
            FavoriteDto.movieId = id;
            FavoriteDto.userName = User.Identity.Name;
            var favorite = Mapper.Map<FavoriteDto, Favorite>(FavoriteDto);
            db.Favorites.Add(favorite);
            db.SaveChanges();

            FavoriteDto.movieId = favorite.movieId;

           // return Created(new Uri(Request.RequestUri + "/" + favorite.movieId), FavoriteDto);

        }

    }
}
