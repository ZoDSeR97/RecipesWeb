using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWeb.Shared
{
    public class Users
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Username { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public int Rep { get; set; } = 0;

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [NotMapped]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Navigation Properties
        public List<Recipes> Recipes { get; set; } = new List<Recipes>();
        public List<Likes> LikedRecipes { get; set; } = new List<Likes>();
    }
}
