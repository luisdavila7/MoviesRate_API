using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesRate_API.Data;
using MoviesRate_API.Models;

namespace MoviesRate_API.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies = _context.Movies.ToList();

            if (movies == null)
            {
                return NotFound();
            }
            return Ok(new { movies });
        }

        [HttpGet("{MovieId}", Name = "GetMovie")]
        public ActionResult<Movie> Get(string movieId)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);
            if (movie == null)
            {
                return NotFound(new { Error_Message = $"Movie {movieId} Not Found!" });
            }
            return Ok(movie);
        }

        [HttpPost]
        public ActionResult PostMovie(Movie movie)
        {
            var findMovie = _context.Movies.FirstOrDefault(x => x.MovieId == movie.MovieId);
            if (findMovie != null)
            {
                return BadRequest(new { Error_Message = "This Movie already exists!" });
            }
            else
            {
                try
                {
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Error_Message = ex.Message });
                }
            }
            return new CreatedAtRouteResult("GetMovie", new {MovieId = movie.MovieId}, movie);
        }

        [HttpDelete("{MovieId}")]
        public ActionResult Delete(string movieId)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);

            if (movie == null)
            {
                return NotFound(new { Error_Message = $"Movie {movieId} Not Found!"});
            } 
            else 
            {
                try
                {
                    _context.Remove(movie);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Error_Message = ex.Message });
                }
            }
            return Ok(movie);
        }

        [HttpPut("{MovieId}")]
        public ActionResult Put(string movieId, Movie movie)
        {
            if (movieId != movie.MovieId)
            {
                return BadRequest(new { Error_Message = "Movie not Found" });
            }
            else
            {
                var movieToUpdate = _context.Movies.FirstOrDefault(x => x.MovieId == movie.MovieId);

                if (movieToUpdate == null)
                {
                    return NotFound(new { Error_Message = $"Movie {movieId} not Found!" });
                }
                else
                {
                    _context.Entry(movieToUpdate).State = EntityState.Detached;

                    try
                    {
                        _context.Movies.Update(movie);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(new { Error_Message = ex.Message });
                    }
                }
            }
            return Ok(movie);
        }

    }
}
