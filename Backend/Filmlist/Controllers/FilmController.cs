using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Filmlist.Classes;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using System.Threading.Tasks;
using System.Linq;

namespace Filmlist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovieListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST api/movielist
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateList([FromBody] MovieList newList)
        {
            if (newList == null || newList.UserId == 0)
            {
                return BadRequest("Invalid movie list or missing user information.");
            }

            var user = await _context.Users.FindAsync(newList.UserId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            newList.User = user;

            foreach (var movie in newList.Movies)
            {
                movie.MovieList = newList;  
            }

            _context.MovieLists.Add(newList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetListById), new { id = newList.Id }, newList);
        }

        // GET api/movielist/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListById(int id)
        {
            var list = await _context.MovieLists.Include(ml => ml.Movies).FirstOrDefaultAsync(ml => ml.Id == id);

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // GET api/movielist/all
        [Authorize]
        [HttpGet("all/{userId:int}")]
        public async Task<IActionResult> GetAllLists(int userId)
        {
            // Check if the user ID is valid
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID");
            }

            var lists = await _context.MovieLists
                .Where(ml => ml.UserId == userId)
                .Include(ml => ml.Movies)
                .ToListAsync();

            if (lists == null || !lists.Any())
            {
                return NotFound();
            }

            return Ok(lists);
        }







        // PUT api/movielist/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateList(int id, [FromBody] MovieList updatedList)
        {
            if (id != updatedList.Id)
            {
                return BadRequest();
            }

            var existingList = await _context.MovieLists.FindAsync(id);
            if (existingList == null)
            {
                return NotFound();
            }

            existingList.Name = updatedList.Name;
            _context.Entry(existingList).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/movielist/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            var list = await _context.MovieLists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            _context.MovieLists.Remove(list);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT api/movielist/{listId}/movie/{movieId}/mark-watched
        [Authorize]
        [HttpPut("{listId}/movie/{movieId}/mark-watched")]
        public async Task<IActionResult> MarkMovieAsWatched(int listId, int movieId)
        {
            var movie = await _context.MovieItems.FirstOrDefaultAsync(mi => mi.MovieListId == listId && mi.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }

            movie.IsWatched = true;
            _context.Entry(movie).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
