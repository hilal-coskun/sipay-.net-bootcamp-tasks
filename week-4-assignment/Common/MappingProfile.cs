using AutoMapper;
using week_3_assignment.BookOperations.GetBooks;
using week_3_assignment.Entities;
using static week_3_assignment.BookOperations.CreateBook.CreateBookCommand;
using static week_3_assignment.BookOperations.GetBookDetails.GetBookDetailQuery;

namespace week_3_assignment.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateBookModel, Book>();
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
		}
	}
}
