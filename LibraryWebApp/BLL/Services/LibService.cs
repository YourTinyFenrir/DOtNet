using LibraryWebApp.BLL.DTO;
using LibraryWebApp.BLL.Interfaces;
using LibraryWebApp.DAL.Interfaces;
using LibraryWebApp.DAL.Entities;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace LibraryWebApp.BLL.Services
{
    public class LibService : ILibService
    {
        IUnitOfWork Database { get; set; }
        int bookIdCounter = 0;
        int readerIdCounter = 0;

        public LibService(IUnitOfWork iuow)
        {
            this.Database = iuow;
        }

        public void CreateBook(BookDTO bookDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
            Book book = mapper.Map<Book>(bookDTO);
            book.Id = bookIdCounter;
            bookIdCounter++;
            Database.Books.Create(book);
            Database.Save();
        }

        public void CreateReader(ReaderDTO readerDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReaderDTO, Reader>()).CreateMapper();
            Reader reader = mapper.Map<Reader>(readerDTO);
            reader.Id = readerIdCounter;
            readerIdCounter++;
            Database.Readers.Create(reader);
            Database.Save();
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(Database.Books.GetAll());
        }

        public IEnumerable<BookDTO> GetFreeBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            var bookDTOs = mapper.Map<IEnumerable<Book>, List<BookDTO>>(Database.Books.GetAll());

            var freeDTOs = new List<BookDTO>();
            foreach (BookDTO dto in bookDTOs)
            {
                if (dto.Owner == null)
                    freeDTOs.Add(dto);
            }

            return freeDTOs;
        }

        public ReaderDTO GetReader(int? ReaderId)
        {
            if (ReaderId == null)
                throw new ArgumentNullException(nameof(ReaderId));

            var reader = Database.Readers.Get(ReaderId.Value);
            if (reader == null)
                throw new InvalidOperationException("Reader was not found");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            List<BookDTO> lst = mapper.Map<IEnumerable<Book>, List<BookDTO>>(reader.BookList);

            return new ReaderDTO { Id = reader.Id, Name = reader.Name, Surname = reader.Surname, BookList = lst };
        }

        public void GiveBook(int? ReaderId, int? BookId)
        {
            if (BookId == null)
                throw new ArgumentNullException(nameof(BookId));

            if (ReaderId == null)
                throw new ArgumentNullException(nameof(ReaderId));

            var book = Database.Books.Get(BookId.Value);
            if (book == null)
                throw new InvalidOperationException("Book was not found");

            var reader = Database.Readers.Get(ReaderId.Value);
            if (reader == null)
                throw new InvalidOperationException("Reader was not found");

            reader.BookList.Add(book);
            book.Owner = reader;

            Database.Readers.Update(reader);
            Database.Books.Update(book);
            Database.Save();
        }

        public void ReturnBook(int? BookId, int? ReaderId)
        {
            if (BookId == null)
                throw new ArgumentNullException(nameof(BookId));

            if (ReaderId == null)
                throw new ArgumentNullException(nameof(ReaderId));

            var book = Database.Books.Get(BookId.Value);
            if (book == null)
                throw new InvalidOperationException("Book was not found");

            var reader = Database.Readers.Get(ReaderId.Value);
            if (reader == null)
                throw new InvalidOperationException("Reader was not found");
            
            reader.BookList.Remove(book);
            book.Owner = null;
            Database.Save();
        }
    }
}
