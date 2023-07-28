using FluentValidation;
using week_3_assignment.BookOperations.CreateBook;

namespace week_3_assignment.BookOperations.DeleteBook
{
	public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
	{
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}
