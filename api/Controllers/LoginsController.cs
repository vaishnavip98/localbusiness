using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly LBReactContext _dbContext;

        public LoginsController(LBReactContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Logins
        [HttpPost]
        public async Task<ActionResult<User>> SignInUser(Login login)
        {
            var userr = await _dbContext.Users.Where(x => x.Email == login.Email).FirstOrDefaultAsync();
            if (userr != null && userr.Password == login.Password)
                return userr;
            else
                return NoContent();
        }
    }
}
