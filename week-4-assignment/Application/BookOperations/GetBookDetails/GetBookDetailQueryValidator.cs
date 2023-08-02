using FluentValidation;
using week_3_assignment.Application.BookOperations.DeleteBook;

namespace week_3_assignment.Application.BookOperations.GetBookDetails
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}
