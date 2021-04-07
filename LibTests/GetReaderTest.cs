using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LibWebApp.DAL.Entities;
using LibWebApp.DAL.Interfaces;
using LibWebApp.BLL.Services;

namespace LibTests
{
    [TestClass]
    public class GetReaderTest
    {
        [TestMethod]
        public void ReaderIdIsNull()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            LibService service = new LibService(mock.Object);

            // Act and assert
            Assert.ThrowsException<System.ArgumentNullException>(() => service.GetReader(null));
        }

        [TestMethod]
        public void ReaderIsNotFound()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Readers.Get(1)).Returns((Reader)null);
            LibService service = new LibService(mock.Object);

            // Act and assert
            Assert.ThrowsException<System.InvalidOperationException>(() => service.GetReader(1));
        }
    }
}
