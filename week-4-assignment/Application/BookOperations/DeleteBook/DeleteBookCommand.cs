using static week_3_assignment.Application.BookOperations.UpdateBook.UpdateBookCommand;
using week_3_assignment.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace week_3_assignment.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int bookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == bookId).FirstOrDefault();

            if (book == null)
                throw new InvalidOperationException("Bad Request");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
