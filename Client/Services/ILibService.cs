using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public interface ILibService
    {
        public void CreateBook(BookDTO bookDTO);
        public void CreateReader(ReaderDTO readerDTO);
        public Task<IEnumerable<BookDTO>> GetFreeBooks();
        public Task<IEnumerable<BookDTO>> GetBooks();
        public Task<ReaderDTO> GetReader(int? ReaderId);
        public void GiveBook(int? ReaderId, int? BookId);
        public void ReturnBook(int? BookId, int? ReaderId);
    }
}
