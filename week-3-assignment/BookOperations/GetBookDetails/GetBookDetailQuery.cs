using Microsoft.EntityFrameworkCore;
using week_3_assignment.Common;
using week_3_assignment.DbOperations;

namespace week_3_assignment.BookOperations.GetBookDetails
{
	public class GetBookDetailQuery
	{
		private readonly BookStoreDbContext _dbContext;
		public int bookId { get; set; }

		public GetBookDetailQuery(BookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		
		public BookDetailViewModel Handle()
		{
			var book = _dbContext.Books.Where(x => x.Id == bookId).FirstOrDefault();
			if (book is null)
				throw new InvalidOperationException("Bad Request");

			BookDetailViewModel vModel = new BookDetailViewModel();
			vModel.Title = book.Title;
			vModel.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
			vModel.Genre = ((GenreEnum)book.GenreId).ToString();
			vModel.PageCount = book.PageCount;
			return vModel;
		}

		public class BookDetailViewModel
		{
			public string Title { get; set; }
			public string Genre { get; set; }
			public int PageCount { get; set; }
			public string PublishDate { get; set; }
		}
	}
}
