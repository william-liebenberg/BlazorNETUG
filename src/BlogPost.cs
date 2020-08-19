using System.ComponentModel.DataAnnotations;

namespace BlazorNETUG
{
    public class BlogPost
    {
		[Required]
        public string Title { get; set; }

		[Required]
		[StringLength(16, ErrorMessage = "Slug is too long (16 character limit).")]
        public string Slug { get; set; }

		[Required]
        public string Content { get; set; }
    }
}