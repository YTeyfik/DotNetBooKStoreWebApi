using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

       /* private static List<Book> BookList = new List<Book>()
       {
           new Book
           {
               Id=1,
               Title="Şu Çılgın Türkler",
               GenreId=1,
               PageCount=200,
               PublishDate=new DateTime(2001,02,11)
           },
           new Book
           {
               Id=2,
               Title="Suç ve Ceza",
               GenreId=2,
               PageCount=250,
               PublishDate=new DateTime(2002,05,12)
           },
           new Book
           {
               Id=3,
               Title="Fareler ve İnsanlar",
               GenreId=1,
               PageCount=500,
               PublishDate=new DateTime(1996,02,11)
           }
       };*/

        [HttpGet]
        public IActionResult GetBooks() 
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result=query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result= query.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        //[HttpGet] //fromquery örneği
       // public Book Get([FromQuery] string id)
       // {
       //     var book = BookList.Where(book => book.Id ==Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
       // }

        
        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
             
            return Ok();
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updateBook;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

    }
}
