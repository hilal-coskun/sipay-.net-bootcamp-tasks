using FluentValidation;
using week_3_assignment.Application.BookOperations.GetBookDetails;

namespace week_3_assignment.Application.GenreOperations.Queries.GetGenreDetail
{
	public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
	{
		public GetGenreDetailQueryValidator()
		{
			RuleFor(command => command.genreId).GreaterThan(0);
		}
	}
}
