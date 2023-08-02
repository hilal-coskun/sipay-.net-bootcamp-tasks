using AutoMapper;
using Microsoft.EntityFrameworkCore;
using week_3_assignment.Common;
using week_3_assignment.DbOperations;

namespace week_3_assignment.BookOperations.GetBookDetails
{
	public class GetBookDetailQuery
	{
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public int bookId { get; set; }

		public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}


		public BookDetailViewModel Handle()
		{
			var book = _dbContext.Books.Where(x => x.Id == bookId).FirstOrDefault();
			if (book is null)
				throw new InvalidOperationException("Bad Request");

			BookDetailViewModel vModel = _mapper.Map<BookDetailViewModel>(book);
			
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
