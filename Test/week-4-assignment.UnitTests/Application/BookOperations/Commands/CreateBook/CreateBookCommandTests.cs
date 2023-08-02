using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static week_3_assignment.Application.BookOperations.CreateBook.CreateBookCommand;
using week_3_assignment.Application.BookOperations.CreateBook;
using week_3_assignment.DbOperations;
using week_3_assignment.Entities;

namespace week_4_assignment.UnitTests.Application.BookOperations.Commands.CreateBook
{
	public class CreateBookCommandTests
	{
		private readonly IBookStoreDBContext _context;
		private readonly IMapper _mappper;

		public CreateBookCommandTests(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mappper = testFixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExitBookTitleIsGivenException_ShouldBeReturn()
		{
			//arrange (Hazırlık)
			var book = new Book() { Title = "Test_WhenAlreadyExitBookTitleIsGivenException_ShouldBeReturn", PageCount = 100, PublisDate = new System.DateTime(1990, 01, 10), GenreId = 1 };
			_context.Books.Add(book);
			_context.SaveChanges();

			CreateBookCommand command = new CreateBookCommand(_context, _mappper);
			command.Model = new CreateBookModel() { Title = book.Title };

			//act (çalıştırma) & Assert (Doğrulama)
			FluentActions
			   .Invoking(() => command.Handle())
			   .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Zaten Mevcut.");
		}

		[Fact]
		public void WhenValidInputsAreaGiven_Book_shouldBeCreated()
		{
			//Arrange
			CreateBookCommand command = new CreateBookCommand(_context, _mappper);
			CreateBookModel model = new CreateBookModel() { Title = "Hobbit", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1 };
			command.Model = model;

			//Act
			FluentActions.Invoking(() => command.Handle()).Invoke();

			//Assert
			var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
			book.Should().NotBeNull();
			book.PageCount.Should().Be(model.PageCount);
			book.PublisDate.Should().Be(model.PublishDate);
			book.GenreId.Should().Be(model.GenreId);
		}
	}
}
}
