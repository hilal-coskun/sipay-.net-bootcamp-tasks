using AutoMapper;
using week_3_assignment.DbOperations;

namespace week_3_assignment.Application.AuthorOperations.Queries.GetAuthorDetail
{
	public class GetAuthorDetailQuery
	{
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public int authorId { get; set; }

		public GetAuthorDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}


		public AuthorDetailViewModel Handle()
		{
			var author = _dbContext.Authors.Where(x => x.Id == authorId).FirstOrDefault();
			if (author is null)
				throw new InvalidOperationException("Bad Request");

			AuthorDetailViewModel vModel = _mapper.Map<AuthorDetailViewModel>(author);

			return vModel;
		}

		public class AuthorDetailViewModel
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string Surname { get; set; }
		}
	}
}
