using FluentValidation;

namespace week_3_assignment.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
	{
        public UpdateGenreCommandValidator()
        {
			RuleFor(g => g.genreId).NotNull().GreaterThan(0);
			RuleFor(g => g.Model.Name).NotNull().MinimumLength(3);
		}
    }
}
