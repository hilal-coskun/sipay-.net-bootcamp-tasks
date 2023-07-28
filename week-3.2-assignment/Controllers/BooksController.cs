using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using week_3_assignment.BookOperations.CreateBook;
using week_3_assignment.BookOperations.DeleteBook;
using week_3_assignment.BookOperations.GetBookDetails;
using week_3_assignment.BookOperations.GetBooks;
using week_3_assignment.BookOperations.UpdateBook;
using week_3_assignment.DbOperations;
using week_3_assignment.Model;
using static week_3_assignment.BookOperations.CreateBook.CreateBookCommand;
using static week_3_assignment.BookOperations.GetBookDetails.GetBookDetailQuery;
using static week_3_assignment.BookOperations.UpdateBook.UpdateBookCommand;

namespace week_3_assignment.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public BooksController(BookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetBooks()
		{
			GetBooksQuery query = new GetBooksQuery(_context, _mapper);
			var result = query.Handle();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			BookDetailViewModel result;

			GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
			try
			{
				query.bookId = id;
				GetBookDetailQueryValidator validationRules = new GetBookDetailQueryValidator();
				validationRules.ValidateAndThrow(query);

				result = query.Handle();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok(result);

		}


		[HttpPost]
		public IActionResult AddBook([FromBody] CreateBookModel entity)
		{
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			try
			{
				command.Model = entity;
				CreateBookCommandValidator validationRules = new CreateBookCommandValidator();
				validationRules.ValidateAndThrow(command);

			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}

			
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel entity)
		{
			UpdateBookCommand command = new UpdateBookCommand(_context);
			try
			{
				command.bookId = id;
				command.Model = entity;

				UpdateBookCommandValidator validationRules = new UpdateBookCommandValidator();
				validationRules.ValidateAndThrow(command);

				command.Handle();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id)
		{
			DeleteBookCommand command = new DeleteBookCommand(_context);
			try
			{
				command.bookId = id;

				DeleteBookCommandValidator validationRules = new DeleteBookCommandValidator();
				validationRules.ValidateAndThrow(command);

				command.Handle();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}
	}
}
