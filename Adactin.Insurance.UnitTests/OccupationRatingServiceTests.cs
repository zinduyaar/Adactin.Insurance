using Adactin.Insurance.Business;
using Xunit;

namespace Adactin.Insurance.UnitTests
{
    public class OccupationRatingServiceTests
    {

        private OccupationRatingService GetSUT()
        {
            return new OccupationRatingService();
        }
        [Fact]
        public void OccupationRatingService_GetRatingFromOccupation_GivenCorrectId_Should_Return_ValidBehaviour()
        {
            // Arrange
            var systemUnderTest = GetSUT();
            var occupationId = 1;

            // Act
            var ratingBehaviour = systemUnderTest.GetRatingFromOccupation(occupationId);
            var factor = ratingBehaviour.GetFactor();

            // Assert
            Assert.Equal(1.5, factor);
        }

        [Fact]
        public void OccupationRatingService_GetRatingFromOccupation_GivenCorrectId_Should_Return_ValidBehaviour_With_DifferentId()
        {
            // Arrange
            var systemUnderTest = GetSUT();
            var occupationId = 2;

            // Act
            var ratingBehaviour = systemUnderTest.GetRatingFromOccupation(occupationId);
            var factor = ratingBehaviour.GetFactor();

            // Assert
            Assert.Equal(1, factor);
        }

        [Fact]
        public void OccupationRatingService_GetRatingFromOccupation_GivenInCorrectId_Should_Return_InValidBehaviour()
        {
            // Arrange
            var systemUnderTest = GetSUT();
            var occupationId = 99;

            // Act
            var ratingBehaviour = systemUnderTest.GetRatingFromOccupation(occupationId);
            var factor = ratingBehaviour.GetFactor();

            // Assert
            Assert.Equal(0, factor);
        }

    }
}