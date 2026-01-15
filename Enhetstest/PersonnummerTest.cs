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
    }
}
