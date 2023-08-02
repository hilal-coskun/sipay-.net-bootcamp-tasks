using AutoMapper;
using week_3_assignment.DbOperations;

namespace week_3_assignment.Application.GenreOperations.Queries.GetGenreDetail
{
	public class GetGenreDetailQuery
	{
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public int genreId { get; set; }

		public GetGenreDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}


		public GenreDetailViewModel Handle()
		{
			var genre = _dbContext.Genres.Where(x => x.IsActive == true && x.Id == genreId).FirstOrDefault();
			if (genre is null)
				throw new InvalidOperationException("Bad Request");

			GenreDetailViewModel vModel = _mapper.Map<GenreDetailViewModel>(genre);

			return vModel;
		}

		public class GenreDetailViewModel
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}
	}
}
