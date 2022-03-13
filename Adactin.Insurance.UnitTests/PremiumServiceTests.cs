using Adactin.Insurance.Business;
using Adactin.Insurance.Core;
using Adactin.Insurance.Domain;
using Adactin.Insurance.Domain.OccupationRating;
using Moq;
using Xunit;

namespace Adactin.Insurance.UnitTests
{
    public class PremiumServiceTests
    {
        Mock<IOccupationRatingService> _occupationRatingServiceMock;
        public PremiumServiceTests()
        {
            _occupationRatingServiceMock = new Mock<IOccupationRatingService>();
        }
        private PremiumService GetSUT()
        {
            return new PremiumService(_occupationRatingServiceMock.Object);
        }
        [Fact]
        public void PremiumService_CalculatePremium_Valid_Factors()
        {
            // Arrange
            var systemUnderTest = GetSUT();
            var factors = new DeathPremiumFactors()
            {
                Age = 31,
                OccupationId = 1,
                SumAssured = 100_000
            };
            _occupationRatingServiceMock.Setup(f => f.GetRatingFromOccupation(1)).Returns(new LightManualRating());

            // Act
            var premium = systemUnderTest.CalculatePremium(factors);

            // Assert
            Assert.Equal(55_800, premium);
        }

        [Fact]
        public void PremiumService_CalculatePremium_Invalid_Factors_Age()
        {
            // Arrange
            var systemUnderTest = GetSUT();
            var factors = new DeathPremiumFactors()
            {
                Age = 0,
                OccupationId = 2,
                SumAssured = 100_000
            };
            _occupationRatingServiceMock.Setup(f => f.GetRatingFromOccupation(2)).Returns(new ProfessionalRating());

            // Act
            var premium = systemUnderTest.CalculatePremium(factors);

            // Assert
            Assert.Equal(0, premium);
        }

        [Fact]
        public void PremiumService_CalculatePremium_Invalid_Factors_SumAssured()
        {
            // Arrange
            var systemUnderTest = GetSUT();
            var factors = new DeathPremiumFactors()
            {
                Age = 31,
                OccupationId = 2,
                SumAssured = 0
            };
            _occupationRatingServiceMock.Setup(f => f.GetRatingFromOccupation(2)).Returns(new ProfessionalRating());

            // Act
            var premium = systemUnderTest.CalculatePremium(factors);

            // Assert
            Assert.Equal(0, premium);
        }

        [Fact]
        public void PremiumService_CalculatePremium_Invalid_Factors_OccupationId()
        {
            // Arrange
            var systemUnderTest = GetSUT();
            var factors = new DeathPremiumFactors()
            {
                Age = 31,
                OccupationId = 0,
                SumAssured = 100_000
            };
            _occupationRatingServiceMock.Setup(f => f.GetRatingFromOccupation(0)).Returns(new DefaultRating());

            // Act
            var premium = systemUnderTest.CalculatePremium(factors);

            // Assert
            Assert.Equal(0, premium);
        }
    }
}