using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWeb.Shared
{
    public class Likes
    {
        public int UserId { get; set; }
        public int RecipesId { get; set; }

        //Navigation Properties
        public Users? User { get; set; }
        public Recipes? Recipe {  get; set; } 
    }
}
