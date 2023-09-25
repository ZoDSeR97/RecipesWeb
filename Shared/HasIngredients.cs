using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWeb.Shared
{
    public class HasIngredients
    {
        [Key]
        public int Id { get; set; }

        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        //Navigation Properties
        public Recipes? Recipe { get; set; }
        public Ingredients? Ingredient { get; set; }
    }
}
