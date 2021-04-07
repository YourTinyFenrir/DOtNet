using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LibWebApp.DAL.Entities;
using LibWebApp.DAL.Interfaces;
using LibWebApp.BLL.Services;

namespace LibTests
{
    [TestClass]
    public class GiveBookTest
    {
        [TestMethod]
        public void ReaderIdIsNull()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            LibService service = new LibService(mock.Object);

            // Act and assert
            Assert.ThrowsException<System.ArgumentNullException>(() => service.GiveBook(null, 5));
        }

        [TestMethod]
        public void BookIdIsNull()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            LibService service = new LibService(mock.Object);

            // Act and assert
            Assert.ThrowsException<System.ArgumentNullException>(() => service.GiveBook(5, null));
        }

        [TestMethod]
        public void ReaderIsNotFound()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Books.Get(1)).Returns(new Book());
            mock.Setup(a => a.Readers.Get(1)).Returns((Reader)null);
            LibService service = new LibService(mock.Object);

            // Act and assert
            Assert.ThrowsException<System.InvalidOperationException>(() => service.GiveBook(1, 1));
        }

        [TestMethod]
        public void BookIsNotFound()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Books.Get(1)).Returns((Book)null);
            mock.Setup(a => a.Readers.Get(1)).Returns(new Reader());
            LibService service = new LibService(mock.Object);

            // Act and assert
            Assert.ThrowsException<System.InvalidOperationException>(() => service.GiveBook(1, 1));
        }
    }
}
