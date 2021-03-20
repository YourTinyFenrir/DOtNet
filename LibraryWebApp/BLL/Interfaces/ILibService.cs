using LibraryWebApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryWebApp.BLL.Interfaces
{
    public interface ILibService
    {
        public void CreateBook(BookDTO bookDTO);
        public void CreateReader(ReaderDTO readerDTO);
        public IEnumerable<BookDTO> GetBooks();
        public IEnumerable<BookDTO> GetFreeBooks();
        public ReaderDTO GetReader(int? ReaderId);
        public void GiveBook(int? ReaderId, int? BookId);
        public void ReturnBook(int? BookId, int? ReaderId);
    }
}
