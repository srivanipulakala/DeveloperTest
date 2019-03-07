using FileData.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FileData.Tests
{
    [TestClass]
    public class FileDetailsServiceTests
    {
        private readonly Mock<IFileDetailsService> _classUnderTest = new Mock<IFileDetailsService>();
        private const string FileName = "sample.txt";

        [TestMethod]
        public void Should_return_valid_file_version()
        {
            _classUnderTest.Setup(f => f.GetVersion(FileName)).Returns("1.0.0");
            Assert.IsTrue(_classUnderTest.Object.GetVersion(FileName) == "1.0.0");
        }

        [TestMethod]
        public void Should_return_valid_file_size()
        {
            _classUnderTest.Setup(f => f.GetSize(FileName)).Returns(10);
            Assert.IsTrue(_classUnderTest.Object.GetSize(FileName) == 10);
        }
    }
}
