﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Movies
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.MovieGenre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/Movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(MovieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            MovieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), MovieDto);
        }

        // PUT /api/Movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MovieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieInDb == null)
            {
                return BadRequest();
            }

            Mapper.Map(MovieDto, MovieInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/Movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var MovieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(MovieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
