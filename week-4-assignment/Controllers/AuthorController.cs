using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static week_3_assignment.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static week_3_assignment.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;
using week_3_assignment.Application.AuthorOperations.Commands.CreateAuthor;
using week_3_assignment.Application.AuthorOperations.Commands.DeleteAuthor;
using week_3_assignment.Application.AuthorOperations.Commands.UpdateAuthor;
using week_3_assignment.Application.AuthorOperations.Queries.GetAuthorDetail;
using week_3_assignment.Application.AuthorOperations.Queries.GetAuthors;
using week_3_assignment.DbOperations;
using FluentValidation;

namespace week_3_assignment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IBookStoreDbContext _context;
		private readonly IMapper _mapper;
		public AuthorController(IBookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAuthors()
		{
			GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
			return Ok(query.Handle());
		}

		[HttpGet("{id}")]
		public IActionResult GetAuthorById(int id)
		{
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);

			GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
			validator.ValidateAndThrow(query);

			query.authorId = id;

			return Ok(query.Handle());
		}

		[HttpPost]
		public IActionResult AddAuthor([FromBody] CreateAuthorViewModel newAuthor)
		{
			CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);

			command.Model = newAuthor;

			CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();

			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorViewModel updatedAuthor)
		{
			UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);

			command.authorId = id;
			command.Model = updatedAuthor;

			UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult RemoveAuthor(int id)
		{
			DeleteAuthorCommand command = new DeleteAuthorCommand(_context);

			command.authorId = id;
			//VALIDATIONS
			command.Handle();

			return Ok();
		}
	}
}
