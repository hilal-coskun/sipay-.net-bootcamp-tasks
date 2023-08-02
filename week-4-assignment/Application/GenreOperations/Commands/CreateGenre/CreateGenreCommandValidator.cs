using FluentValidation;

namespace week_3_assignment.Application.GenreOperations.Commands.CreateGenre
{
	public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
	{
        public CreateGenreCommandValidator()
        {
			RuleFor(g => g.Model.Name).NotNull().MinimumLength(3);
		}
    }
}
