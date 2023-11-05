using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesWeb.Server.Models;
using RecipesWeb.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {

        MyContext _context;

        public IngredientController(MyContext context)
        {
            _context = context;
        }

        // GET: api/<IngredientController>
        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            return _context.Ingredients.ToList();
        }

        // GET api/<IngredientController>/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var ingredient = _context.Ingredients
                .Include(record => record.InRecipe).ThenInclude(record => record.Recipe)
                .FirstOrDefault(record => record.Name == name);
            if (ingredient == null) { return NotFound(); }
            return Ok(ingredient);
        }

        // POST api/<IngredientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IngredientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
