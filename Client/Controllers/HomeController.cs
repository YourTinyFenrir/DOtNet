using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Client.Services;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private ILibService service { get; }

        public HomeController(ILibService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View("~/Views/CreateBook.cshtml");
        }

        [HttpPost]
        public IActionResult CreateBook(String author, String name)
        {
            try
            {
                BookDTO bDTO = new BookDTO
                {
                    Author = author,
                    Name = name,
                };
                service.CreateBook(bDTO);

                return Content("Книга добавлена");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult CreateReader()
        {
            return View("~/Views/CreateReader.cshtml");
        }

        [HttpPost]
        public IActionResult CreateReader(String name, String surname)
        {
            try
            {
                ReaderDTO rDTO = new ReaderDTO
                {
                    Name = name,
                    Surname = surname,
                };
                service.CreateReader(rDTO);

                return Content("Читатель добавлен");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public IActionResult GetBooks()
        {
            try
            {
                var books = service.GetBooks().Result;
                return View("~/Views/GetBooks.cshtml", books);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public IActionResult GetReader(int? readerId)
        {
            try
            {
                ReaderDTO reader = service.GetReader(readerId).Result;
                return View("~/Views/GetReader.cshtml", reader);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GiveBook()
        {
            try
            {
                var freeBooks = service.GetFreeBooks().Result;
                return View("~/Views/GiveBook.cshtml", freeBooks);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult GiveBook(int? bookId, int? readerId)
        {
            try
            {
                service.GiveBook(bookId, readerId);
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
                var reader = service.GetReader(readerId).Result;
                return View("~/Views/ReturnBook.cshtml", reader.BookList);
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
