using FluentValidation;
using week_3_assignment.BookOperations.DeleteBook;

namespace week_3_assignment.BookOperations.GetBookDetails
{
	public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
	{
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}
