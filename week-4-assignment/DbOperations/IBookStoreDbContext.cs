using Microsoft.EntityFrameworkCore;
using week_3_assignment.Entities;

namespace week_3_assignment.DbOperations
{
	public interface IBookStoreDbContext
	{
		DbSet<Book> Books { get; set; }
		DbSet<Genre> Genres { get; set; }
		DbSet<Author> Authors { get; set; }

		int SaveChanges();
	}
}
