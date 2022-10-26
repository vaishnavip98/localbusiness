using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LBReactContext _dbContext;

        public UsersController(LBReactContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }
            return await _dbContext.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            if (_dbContext.Users == null)
            {
                return NoContent();
            }
            var user = await _dbContext.Users.Where(u=>u.Email==id).FirstOrDefaultAsync();

            if (user == null)
            {
                return NoContent();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _dbContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }

            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _dbContext.Users.Any(e => e.UserId == id);
        }
    }
}
