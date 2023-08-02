using FluentValidation;
using week_3_assignment.Application.BookOperations.GetBookDetails;

namespace week_3_assignment.Application.AuthorOperations.Queries.GetAuthorDetail
{
	public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
	{
		public GetAuthorDetailQueryValidator()
		{
			RuleFor(command => command.authorId).GreaterThan(0);
		}
	}
}
