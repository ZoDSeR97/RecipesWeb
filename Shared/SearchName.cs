using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWeb.Shared
{
    public class SearchName
    {
        [Required]
        [MinLength(2)]
        public string? Name { get; set; }
    }
}
