using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week_3_assignment.Model;

namespace week_3_assignment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private static List<Book> books = new List<Book>()
		{
			new Book
			{
				Id = 1,
				Title = "Lean Startup",
				GenreId = 1, // Personal Growth
				PageCount = 200,
				PublishDate = new DateTime(2001,06,12)
			},
			new Book
			{
				Id = 2,
				Title = "Herland",
				GenreId = 2, // Science Fiction
				PageCount = 250,
				PublishDate = new DateTime(2010,09,12)
			},
			new Book
			{
				Id = 1,
				Title = "Dune",
				GenreId = 2, // Personal Growth
				PageCount = 540,
				PublishDate = new DateTime(2001,06,12)
			}
		};

		[HttpGet]
		public List<Book> GetBooks()
		{
			var bookList = books.OrderBy(x => x.Id).ToList<Book>();

			return bookList;
		}

		[HttpGet("{id}")]
		public Book GetById(int id)
		{
			var book = books.Where(x => x.Id == id).FirstOrDefault();

			return book;
		}

		/*[HttpGet]
		public Book Get([FromQuery] string id)
		{
			var book = books.Where(x => x.Id == Convert.ToInt32(id)).FirstOrDefault();

			return book;
		}*/

		[HttpPost]
		public IActionResult AddBook([FromBody] Book entity)
		{
			var book = books.FirstOrDefault(x => x.Title == entity.Title);

			if (book != null)
				return BadRequest();

			books.Add(entity);
			return Ok();
		}
	}
}
