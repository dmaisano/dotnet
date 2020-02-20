using System.Linq;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {

        private readonly DataContext context;

        public ValuesController(DataContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult GetValues()
        {
            var values = context.Values.ToList();

            return Ok(values);
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = context.Values.Where(x => x.RecID == id).FirstOrDefault();

            return Ok(value);
        }
    }
}
