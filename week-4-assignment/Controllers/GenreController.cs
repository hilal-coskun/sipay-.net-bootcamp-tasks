using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static week_3_assignment.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using week_3_assignment.Application.GenreOperations.Commands.CreateGenre;
using week_3_assignment.Application.GenreOperations.Commands.DeleteGenre;
using week_3_assignment.Application.GenreOperations.Commands.UpdateGenre;
using week_3_assignment.Application.GenreOperations.Queries.GetGenreDetail;
using week_3_assignment.Application.GenreOperations.Queries.GetGenres;
using week_3_assignment.DbOperations;
using FluentValidation;

namespace week_3_assignment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : ControllerBase
	{
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public GenreController(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetGenres()
		{
			GetGenresQuery query = new GetGenresQuery(_dbContext, _mapper);
			return Ok(query.Handle());
		}

		[HttpGet("{id}")]
		public IActionResult GetGenreById(int id)
		{
			GetGenreDetailQuery query = new GetGenreDetailQuery(_dbContext, _mapper);
			query.genreId = id;

			GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
			validator.ValidateAndThrow(query);

			return Ok(query.Handle());
		}

		[HttpPost]
		public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
		{
			CreateGenreCommand command = new CreateGenreCommand(_dbContext, _mapper);
			command.Model = newGenre;

			CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();

			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreCommand.UpdateGenreViewModel updatedGenre)
		{
			UpdateGenreCommand command = new UpdateGenreCommand(_dbContext, _mapper);

			command.genreId = id;
			command.Model = updatedGenre;

			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult RemoveGenre(int id)
		{
			DeleteGenreCommand command = new DeleteGenreCommand(_dbContext);

			command.GenreId = id;
			command.Handle();

			return Ok();
		}
	}
}
