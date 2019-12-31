using System.Linq;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
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
    }
}