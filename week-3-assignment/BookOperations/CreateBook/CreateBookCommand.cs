using Microsoft.EntityFrameworkCore;
using week_3_assignment.DbOperations;
using week_3_assignment.Model;

namespace week_3_assignment.BookOperations.CreateBook
{
	public class CreateBookCommand
	{
		public CreateBookModel Model { get; set; }
		private readonly BookStoreDbContext _dbContext;

		public CreateBookCommand(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Handle()
		{
			var book = _dbContext.Books.FirstOrDefault(x => x.Title == Model.Title);

			if (book != null)
				throw new InvalidOperationException("Bad Request");

			book = new Book();
			book.Title = Model.Title;
			book.PublishDate = Model.PublishDate;
			book.PageCount = Model.PageCount;
			book.GenreId = Model.GenreId;

			_dbContext.Books.Add(book);
			_dbContext.SaveChanges();
		}

		public class CreateBookModel
		{
			public string Title { get; set; }
			public int GenreId { get; set; }
			public int PageCount { get; set; }
			public DateTime PublishDate { get; set; }
		}
	}
}
