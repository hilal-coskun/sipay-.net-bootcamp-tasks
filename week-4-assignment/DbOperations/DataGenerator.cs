using Microsoft.EntityFrameworkCore;
using week_3_assignment.Entities;

namespace week_3_assignment.DbOperations
{
	public class DataGenerator
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
			{
				if(context.Books.Any())
				{
					return;
				}

				context.Genres.AddRange(
					new Genre
					{
						Name = "PersonalGrowth"
					},
					new Genre
					{
						Name = "ScienceFiction"
					},
					new Genre
					{
						Name = "Noval"
					}
				);

				context.Authors.AddRange(
					new Author
					{
						Name = "",
						Surname = "",
						BirthDate = DateTime.Now,
					},
					new Author
					{
						Name = "",
						Surname = "",
						BirthDate = DateTime.Now,
					},
					new Author
					{
						Name = "",
						Surname = "",
						BirthDate = DateTime.Now,
					}
				);

				context.Books.AddRange(
					new Book
					{
						Title = "Lean Startup",
						GenreId = 1, // Personal Growth
						PageCount = 200,
						PublishDate = new DateTime(2001, 06, 12)
					},
					new Book
					{
						Title = "Herland",
						GenreId = 2, // Science Fiction
						PageCount = 250,
						PublishDate = new DateTime(2010, 09, 12)
					},
					new Book
					{
						Title = "Dune",
						GenreId = 2, // Personal Growth
						PageCount = 540,
						PublishDate = new DateTime(2001, 06, 12)
					}
				);
				context.SaveChanges();
			}
		}
	}
}
