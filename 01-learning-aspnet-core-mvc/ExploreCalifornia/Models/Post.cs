using System;
using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia.Models
{
    public class Post
    {
        [Display(Name = "Post title")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength (150, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 150 characters long.")]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(100, ErrorMessage = "Your blog post must be atleast 100 characters long.")]
        public string Body { get; set; }
        public DateTime PostedAt { get; set; }

    }
}
