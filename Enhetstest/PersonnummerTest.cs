using Personnummer;

namespace Enhetstest
{
    public class PersonnummerTest
    {
        [Fact]
        public void IsCorrectLength_ReturnTrue_10digits()
        {
            //Arrange
            var validator = new PersonnummerValidator();

            //Act
            bool result = validator.IsCorrectLength("8111011237");

            //Assert
            Assert.True(result);

        }

        [Fact]
        public void IsDateValid_ReturnTrue_CorrectDate()
        {
            // Arrange
            var validator = new PersonnummerValidator();

            // Act (Testar 18:e december, vilket är giltigt)
            bool result = validator.IsDateValid("8112189876");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsDateValid_ReturnFalse_InvalidMonth()
        {
            // Arrange
            var validator = new PersonnummerValidator();

            // Act (Testar månad 13, vilket inte finns)
            bool result = validator.IsDateValid("8113019876");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsDateValid_ReturnFalse_InvalidDay()
        {
            // Arrange
            var validator = new PersonnummerValidator();

            // Act (Testar dag 32, vilket inte finns)
            bool result = validator.IsDateValid("8101329876");

            // Assert
            Assert.False(result);
        }
    }
}
