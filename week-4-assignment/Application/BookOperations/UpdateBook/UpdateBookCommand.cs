using Microsoft.EntityFrameworkCore;
using week_3_assignment.DbOperations;
using static week_3_assignment.Application.BookOperations.CreateBook.CreateBookCommand;

namespace week_3_assignment.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public UpdateBookViewModel Model { get; set; }
        public int bookId { get; set; }

        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
                throw new InvalidOperationException("Bad Request");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _dbContext.SaveChanges();
        }

        public class UpdateBookViewModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}
