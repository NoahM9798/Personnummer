using Personnummer;
using Xunit;

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
            bool result = validator.IsCorrectLength("8411011237");

            //Assert
            Assert.True(result);
        }

        // --- Tester för IsDateValid (Datumkontroll) ---
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

        // --- Tester för IsControlDigitValid (Luhn-algoritmen) ---
        [Fact]
        public void IsControlDigitValid_ReturnTrue_WhenDigitIsCorrect()
        {
            // Arrange
            var validator = new PersonnummerValidator();
            long validPnr = 8112189876; // Ett giltigt testnummer

            // Act
            bool result = validator.IsControlDigitValid(validPnr);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsControlDigitValid_ReturnFalse_WhenDigitIsWrong()
        {
            // Arrange
            var validator = new PersonnummerValidator();
            long invalidPnr = 8112189877; // Felaktig sista siffra (ska vara 6)

            // Act
            bool result = validator.IsControlDigitValid(invalidPnr);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HyphenRemover_ReturnsStringWithoutHyphen()
        {
            // Arrange
            var validator = new PersonnummerValidator();
            string input = "811218-9876";
            // Act
            string result = validator.HyphenRemover(input);
            // Assert
            Assert.Equal("8112189876", result);
        }
    }
}
