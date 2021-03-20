using Microsoft.AspNetCore.Mvc;
using LibraryWebApp.BLL.Interfaces;
using LibraryWebApp.BLL.DTO;
using System.Collections.Generic;
using System;

namespace LibraryWebApp.WebAPI.Controllers
{
    public class LibController : Controller
    {
        private ILibService service;

        public LibController(ILibService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View("~/Pages/CreateBook.cshtml");
        }

        [HttpPost]
        public IActionResult CreateBook(String author, String name)
        {
         
            BookDTO bDTO = new BookDTO
            {
                Author = author,
                Name = name,
            };
            service.CreateBook(bDTO);

            return Content("Книга добавлена");
        }

        [HttpGet]
        public IActionResult CreateReader()
        {
            return View("~/Pages/CreateReader.cshtml");
        }

        [HttpPost]
        public IActionResult CreateReader(String name, String surname)
        {
            ReaderDTO rDTO = new ReaderDTO
            {
                Name = name,
                Surname = surname,
            };
            service.CreateReader(rDTO);

            return Content("Читатель добавлен");
        }

        public IActionResult GetBooks()
        {
            IEnumerable<BookDTO> books = service.GetBooks();
            return View("~/Pages/GetBooks.cshtml", books);
        }

        public IActionResult GetReader(int? readerId)
        {
            try
            {
                ReaderDTO reader = service.GetReader(readerId);
                return View("~/Pages/GetReader.cshtml", reader);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GiveBook()
        {
            var freeBooks = service.GetFreeBooks();
            return View("~/Pages/GiveBook.cshtml", freeBooks);
        }

        [HttpPost]
        public IActionResult GiveBook(int? bookId, int? readerId)
        {
            try
            {
                service.GiveBook(readerId, bookId);
                return Content("Данные о выдаче книги сохранены");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ReturnBook(int? readerId)
        {
            try
            {
                var reader = service.GetReader(readerId);
                return View("~/Pages/ReturnBook.cshtml", reader.BookList);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult ReturnBook(int? bookId, int? readerId)
        {
            try
            {
                service.ReturnBook(bookId, readerId);
                return Content("Данные о возврате книги сохранены");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

    }
}
