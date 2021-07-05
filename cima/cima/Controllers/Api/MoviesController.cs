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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db;

        public MoviesController()
        {
            db = new ApplicationDbContext();
        }

        // Get /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
           return db.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // Get /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.movieid == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));  
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(MovieDto);
            db.Movies.Add(movie);
            db.SaveChanges();

            MovieDto.movieid = movie.movieid;

            return Created(new Uri(Request.RequestUri + "/" + movie.movieid), MovieDto);

        }

        //PUT/api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = db.Movies.SingleOrDefault(c => c.movieid == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);
            /*movieInDb.MovieGenre = (movieGenre)movieDto.MovieGenre;
            movieInDb.releaseDate = movieDto.releaseDate;
            movieInDb.movieName = movieDto.movieName;
            movieInDb.movieYear = movieDto.movieYear;
            movieInDb.userName = movieDto.userName;
            movieInDb.movieSeason = movieDto.movieSeason;
            movieInDb.starring = movieDto.starring;
            movieInDb.creator = movieDto.creator;*/

            db.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = db.Movies.SingleOrDefault(c => c.movieid == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Movies.Remove(movieInDb);
            db.SaveChanges();
        }

    }
}
