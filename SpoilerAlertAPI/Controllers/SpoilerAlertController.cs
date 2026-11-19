using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpoilerAlertAPI.DTOs;
using SpoilerAlertAPI.Models;
using System.Data;
using System.Reflection;

namespace SpoilerAlertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpoilerAlertController : ControllerBase
    {
        private readonly IDbConnection _db;

        // Constructor
        public SpoilerAlertController(IDbConnection db) { 
            // Initialize
            _db = db;

        }

        [HttpGet]   
        public async Task<ActionResult<IEnumerable<SpoilerAlert>>> GetAllMovies()
        {

            var sql = "SELECT m.*, g.*, r.*, d.* " +
                "FROM Movie m " +
                "INNER JOIN Genre g ON m.GenreId = g.Id " +
                "INNER JOIN AudienceRating r ON m.AudienceRatingId = r.Id " +
                "INNER JOIN Director d ON m.DirectorId = d.Id";

             

            var movies = await _db.QueryAsync<SpoilerAlert, Genre, AudienceRating, Director, SpoilerAlert>(sql,
                (movie, genre, rating, director) =>
                {
                    movie.Genre = genre;
                    movie.AudienceRating = rating;
                    movie.Director = director;
                    return movie;
                },
                splitOn: "Id");
            
                return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<SpoilerAlert>>> GetMovieById(int id)
        {
            var sql = "SELECT m.*, g.*, r.*, d.*, cr.*, u.* " +
                "FROM Movie m " +
                "INNER JOIN Genre g ON m.GenreId = g.Id " +
                "INNER JOIN AudienceRating r ON m.AudienceRatingId = r.Id " +
                "INNER JOIN Director d ON m.DirectorId = d.Id " +
                "LEFT OUTER JOIN CriticReview cr ON m.Id = cr.MovieId AND cr.IsPublished = 1" +
                "LEFT OUTER JOIN UserSnapshot u ON cr.CreatedBy = u.UserId "+
                "WHERE m.Id = @Id";

            SpoilerAlert? movie = null;

            await _db.QueryAsync<SpoilerAlert, Genre, AudienceRating, Director, CriticReview, UserSnapshot, SpoilerAlert>(sql,
                (m, g, r, d, cr, u) =>
                {
                    if (movie == null)
                    {
                        movie = m;
                        movie.Genre = g;
                        movie.AudienceRating = r;
                        movie.Director = d;
                        movie.CriticReview = new List<CriticReview>();
                    }

                    if(cr != null)
                    {
                        cr.UserSnapshot = u;
                        movie.CriticReview.Add(cr);
                    }
                    return movie;
                },
                new { Id = id },
                splitOn: "Id,Id,Id,Id,UserId");

            return Ok(movie);
        }

    }
}
