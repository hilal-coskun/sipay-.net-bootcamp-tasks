using Microsoft.EntityFrameworkCore;
using week_3_assignment.Model;

namespace week_3_assignment.DbOperations
{
	public class BookStoreDbContext: DbContext
	{
		public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

		public DbSet<Book> Books { get; set; }
	}
}
