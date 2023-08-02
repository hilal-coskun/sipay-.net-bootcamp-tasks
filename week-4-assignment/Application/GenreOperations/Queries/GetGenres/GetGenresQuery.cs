using AutoMapper;
using week_3_assignment.Application.BookOperations.GetBooks;
using week_3_assignment.DbOperations;

namespace week_3_assignment.Application.GenreOperations.Queries.GetGenres
{
	public class GetGenresQuery
	{
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetGenresQuery(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public List<GenresViewModel> Handle()
		{
			var genreList = _dbContext.Genres.Where(x=> x.IsActive == true).OrderBy(x => x.Id).ToList();
			List<GenresViewModel> vmodel = _mapper.Map<List<GenresViewModel>>(genreList);

			return vmodel;
		}
	}

	public class GenresViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
 