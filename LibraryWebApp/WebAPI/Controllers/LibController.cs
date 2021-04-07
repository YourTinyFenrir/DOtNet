using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibraryWebApp.BLL.Interfaces;
using LibraryWebApp.BLL.DTO;

namespace LibraryWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibController : ControllerBase
    {
        ILibService service;

        public LibController(ILibService service)
        {
            this.service = service;
        }

        [HttpPut]
        public void CreateBook(BookDTO bookDTO)
        {
            service.CreateBook(bookDTO);
        }

        [HttpPut]
        public void CreateReader(ReaderDTO readerDTO)
        {
            service.CreateReader(readerDTO);
        }

        [HttpGet]
        public IEnumerable<BookDTO> GetBooks()
        {
            IEnumerable<BookDTO> books = service.GetBooks();
            return books;
        }

        [HttpGet]
        public ReaderDTO GetReader(int? readerId)
        {
            ReaderDTO reader = service.GetReader(readerId);
            return reader;
        }

        [HttpGet]
        public IEnumerable<BookDTO> GetFreeBooks()
        {
            IEnumerable<BookDTO> books = service.GetFreeBooks();
            return books;
        }

        [HttpGet]
        public IEnumerable<BookDTO> GiveBook()
        {
            IEnumerable<BookDTO> freeBooks = service.GetFreeBooks();
            return freeBooks;
        }

        [HttpPut]
        public void GiveBook(int? bookId, int? readerId)
        {
            service.GiveBook(bookId, readerId);
        }


        [HttpGet]
        public List<BookDTO> ReturnBook(int? readerId)
        {
            ReaderDTO reader = service.GetReader(readerId);
            return reader.BookList;
        }

        [HttpPut]
        public void ReturnBook(int? bookId, int? readerId)
        {
            service.ReturnBook(bookId, readerId);
        }
    }
}
