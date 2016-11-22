using BoilerPlate.Service;
using Xunit;

namespace BoilerPlate.Unit.Tests
{
    public class ImagesServiceTest
    {
        private ImagesService _imageService;

        public ImagesServiceTest()
        {
            _imageService = new ImagesService();
        }

        [Fact]
        public void GetPictures_ReturnsAllPictures()
        {
            var allPictures = _imageService.GetPictures();
            Assert.Equal(allPictures.Count, 11);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void GetPicture_GetPictureWithExistingId_ReturnsPicture(int validId)
        {
            var picture = _imageService.GetPicture(validId);
            Assert.NotNull(picture);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void GetPicture_GetPictureWithNotExistingId_ReturnsNull(int invalidId)
        {
            var picture = _imageService.GetPicture(invalidId);
            Assert.Null(picture);
        }
    }
}
