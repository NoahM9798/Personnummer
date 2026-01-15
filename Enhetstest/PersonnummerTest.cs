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
            bool result = validator.IsCorrectLength("8111011237");

            //Assert
            Assert.True(result);

        }
        //---Tester för IsControldigitValid---
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
    }
}
