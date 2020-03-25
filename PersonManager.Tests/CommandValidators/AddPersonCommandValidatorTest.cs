using PersonManager.Api.Commands;
using PersonManager.Api.CommandValidators;
using Xunit;

namespace PersonManager.Tests.CommandValidators
{
    public class AddPersonCommandValidatorTest
    {
        [Fact]
        public void Validate_Returns_No_Error_When_All_The_Conditions_Are_Met()
        {
            // Arrange
            var sut = new AddPersonCommandValidator();
            // Act
            var validation = sut.Validate(NewAddPersonCommand());
            //Assert
            Assert.True(validation.IsValid);
        }

        [Fact]
        public void Validate_Returns_1_Error_When_Name_Is_Null()
        {
            // Arrange
            var sut = new AddPersonCommandValidator();
            // Act
            var validation = sut.Validate(NewAddPersonCommand(null));
            //Assert
            Assert.False(validation.IsValid);
            Assert.Equal(1, validation.Errors.Count);
            Assert.Equal("Name", validation.Errors[0].PropertyName);
            Assert.Equal("NotEmptyValidator", validation.Errors[0].ErrorCode);
        }

        [Fact]
        public void Validate_Returns_1_Error_When_Name_Is_Empty()
        {
            // Arrange
            var sut = new AddPersonCommandValidator();
            // Act
            var validation = sut.Validate(NewAddPersonCommand(""));
            //Assert
            Assert.False(validation.IsValid);
            Assert.Equal(1, validation.Errors.Count);
            Assert.Equal("Name", validation.Errors[0].PropertyName);
            Assert.Equal("NotEmptyValidator", validation.Errors[0].ErrorCode);
        }

        [Fact]
        public void Validate_Returns_1_Error_When_GroupId_Is_Lower_Than_0()
        {
            // Arrange
            var sut = new AddPersonCommandValidator();
            // Act
            var validation = sut.Validate(NewAddPersonCommand("New Person", -1));
            //Assert
            Assert.False(validation.IsValid);
            Assert.Equal(1, validation.Errors.Count);
            Assert.Equal("GroupId", validation.Errors[0].PropertyName);
            Assert.Equal("GreaterThanValidator", validation.Errors[0].ErrorCode);
        }

        [Fact]
        public void Validate_Returns_1_Error_When_GroupId_Is_0()
        {
            // Arrange
            var sut = new AddPersonCommandValidator();
            // Act
            var validation = sut.Validate(NewAddPersonCommand("New Person", 0));
            //Assert
            Assert.False(validation.IsValid);
            Assert.Equal(1, validation.Errors.Count);
            Assert.Equal("GroupId", validation.Errors[0].PropertyName);
            Assert.Equal("GreaterThanValidator", validation.Errors[0].ErrorCode);
        }

        private AddPersonCommand NewAddPersonCommand(
            string name = "New Person",
            int groupId = 1)
        {
            return new AddPersonCommand
            {
                Name = name,
                GroupId = groupId
            };
        }
    }
}
