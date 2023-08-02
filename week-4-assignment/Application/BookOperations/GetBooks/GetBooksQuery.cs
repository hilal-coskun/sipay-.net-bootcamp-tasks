using AutoMapper;
using Microsoft.EntityFrameworkCore;
using week_3_assignment.Common;
using week_3_assignment.DbOperations;
using week_3_assignment.Entities;

namespace week_3_assignment.Application.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vmodel = _mapper.Map<List<BooksViewModel>>(bookList);

            return vmodel;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
