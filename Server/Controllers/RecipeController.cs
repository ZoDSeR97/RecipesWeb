using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesWeb.Server.Models;
using RecipesWeb.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        MyContext _context;

        public RecipeController(MyContext context)
        {
            _context = context;
        }

        // GET: api/<RecipeController>
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _context.Recipes
                .Include(record => record.Creator)
                .Include(record => record.LikeBy)
                .Include(record => record.HasIngredient).ThenInclude(record => record.Ingredient).ToList();
        }

        // GET api/<RecipeController>/5
        [HttpGet("{name}")]
        public IEnumerable<Recipe> Get(string name)
        {
            return _context.Recipes
                .Include(record => record.Creator)
                .Include(record => record.LikeBy)
                .Include(record => record.HasIngredient).ThenInclude(record => record.Ingredient)
                .Where(record => record.Name == name || record.HasIngredient.Any(i => i.Ingredient.Name == name))
                .ToList();
        }

        // POST api/<RecipeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
