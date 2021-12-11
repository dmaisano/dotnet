using api.Data;
using api.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;

        }

        [Authorize]
        [HttpGet("auth")]
        public async Task<ActionResult<string>> GetSecret()
        {
            return await Task.Run(() => "secret text");
        }

        [HttpGet("not-found")]
        public async Task<ActionResult<AppUser>> GetNotFound()
        {
            var thing = await _context.Users.FindAsync(-1);

            if (thing == null) return NotFound();

            return Ok(thing);
        }

        [HttpGet("server-error")]
        public async Task<ActionResult<string>> GetServerError()
        {
            var thing = await _context.Users.FindAsync(-1);

            // should be null and throw a null reference exception
            var result = thing.ToString();

            return result;

            // try
            // {
            //     var thing = await _context.Users.FindAsync(-1);

            //     // should be null and throw a null reference exception
            //     var result = thing.ToString();

            //     return result;
            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, "What's going on here?");
            // }
        }

        [HttpGet("bad-request")]
        public async Task<ActionResult<string>> GetBadRequest()
        {
            return await Task.Run(() => BadRequest("This was not a good request"));
        }
    }
}
