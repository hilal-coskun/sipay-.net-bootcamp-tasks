using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

		public BooksController(BookStoreDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetBooks()
		{
			GetBooksQuery query = new GetBooksQuery(_context);
			var result = query.Handle();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			BookDetailViewModel result;

			GetBookDetailQuery query = new GetBookDetailQuery(_context);
			try
			{
				query.bookId = id;
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
			CreateBookCommand command = new CreateBookCommand(_context);
			try
			{
				command.Model = entity;
				command.Handle();
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
