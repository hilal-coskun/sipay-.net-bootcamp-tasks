using AutoMapper;
using week_3_assignment.DbOperations;

namespace week_3_assignment.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommand
	{
		public int genreId { get; set; }
		public UpdateGenreViewModel Model { get; set; }
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public UpdateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public void Handle()
		{
			var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == genreId);

			if (genre is null)
				throw new InvalidOperationException("Bad Request");
			if (_dbContext.Genres.Any(g => genre.Name.ToLower() == Model.Name.ToLower() && g.Id == genreId))
				throw new InvalidOperationException("Bad Request");

			_mapper.Map(Model, genre);

			_dbContext.SaveChanges();
		}
		public class UpdateGenreViewModel
		{
			public string Name { get; set; }
			public bool IsActive { get; set; }
		}
	}
}
