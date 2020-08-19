using FluentValidation;

namespace BlazorNETUG
{
	public class BlogPostValidator : AbstractValidator<BlogPost>
	{
		public BlogPostValidator()
		{
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.Slug).NotEmpty().Length(3,16);
			RuleFor(x => x.Content).NotEmpty();
		}
	}
}