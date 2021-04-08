using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibWebApp.BLL.Interfaces;
using LibWebApp.BLL.DTO;

namespace LibWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibController : ControllerBase
    {
        ILibService service;

        public LibController(ILibService service)
        {
            this.service = service;
        }

        [HttpPut]
        [Route("/lib/CreateBook")]
        public void CreateBook(BookDTO bookDTO)
        {
            service.CreateBook(bookDTO);
        }

        [HttpPut]
        [Route("/lib/CreateReader")]
        public void CreateReader(ReaderDTO readerDTO)
        {
            service.CreateReader(readerDTO);
        }

        [HttpGet]
        [Route("/lib/GetBooks")]
        public IEnumerable<BookDTO> GetBooks()
        {
            IEnumerable<BookDTO> books = service.GetBooks();
            return books;
        }

        [HttpGet]
        [Route("/lib/GetReader")]
        public ReaderDTO GetReader(int? readerId)
        {
            ReaderDTO reader = service.GetReader(readerId);
            return reader;
        }

        [HttpGet]
        [Route("/lib/GetFreeBooks")]
        public IEnumerable<BookDTO> GetFreeBooks()
        {
            IEnumerable<BookDTO> books = service.GetFreeBooks();
            return books;
        }

        [HttpGet]
        [Route("/lib/GiveBook")]
        public IEnumerable<BookDTO> GiveBook()
        {
            IEnumerable<BookDTO> freeBooks = service.GetFreeBooks();
            return freeBooks;
        }

        [HttpPut]
        [Route("/lib/GiveBook")]
        public void GiveBook([FromBody] Dictionary<string, int?> data)
        {
            service.GiveBook(data["ReaderId"], data["BookId"]);
        }


        [HttpGet]
        [Route("/lib/ReturnBook")]
        public List<BookDTO> ReturnBook(int? readerId)
        {
            ReaderDTO reader = service.GetReader(readerId);
            return reader.BookList;
        }

        [HttpPut]
        [Route("lib/ReturnBook")]
        public void ReturnBook([FromBody] Dictionary<string, int?> data)
        {
            service.ReturnBook(data["BookId"], data["ReaderId"]);
        }
    }
}
