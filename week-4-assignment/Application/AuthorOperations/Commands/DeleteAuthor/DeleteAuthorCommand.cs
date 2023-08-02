using week_3_assignment.DbOperations;

namespace week_3_assignment.Application.AuthorOperations.Commands.DeleteAuthor
{
	public class DeleteAuthorCommand
	{
		public int authorId { get; set; }
		private readonly IBookStoreDbContext _dbContext;

		public DeleteAuthorCommand(IBookStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void Handle()
		{
			var author = _dbContext.Authors.SingleOrDefault(a => a.Id == authorId);
			var authorBooks = _dbContext.Books.SingleOrDefault(a => a.AuthorId == authorId);

			if (author is null)
				throw new InvalidOperationException("Bad Request");

			if (authorBooks is not null)
				throw new InvalidOperationException(author.Name + " " + author.Surname + " has a published book. Please delete book first.");

			_dbContext.Authors.Remove(author);
			_dbContext.SaveChanges();
		}
	}
}
