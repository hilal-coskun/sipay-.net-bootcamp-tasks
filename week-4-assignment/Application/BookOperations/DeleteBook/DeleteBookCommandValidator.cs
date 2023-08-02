using FluentValidation;
using week_3_assignment.Application.BookOperations.CreateBook;

namespace week_3_assignment.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}
