﻿using FluentValidation;

namespace week_3_assignment.Application.AuthorOperations.Commands.CreateAuthor
{
	public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
	{
		public CreateAuthorCommandValidator()
		{
			RuleFor(a => a.Model.Name).MinimumLength(2).NotEmpty();
			RuleFor(a => a.Model.Surname).MinimumLength(2).NotEmpty();
			RuleFor(a => a.Model.Birthday.Date).LessThan(DateTime.Now.Date);
		}
	}
}
