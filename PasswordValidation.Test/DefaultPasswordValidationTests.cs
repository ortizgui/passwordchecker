using System;
using Xunit;
using PasswordValidation.Core.Services;
using PasswordValidation.Core.Dtos;

namespace PasswordValidation.Test
{
    public class DefaultPasswordValidationTests
    {
        [Fact]
        public void DefaultPasswordValidation_PasswordNull_ReturnIsFalse()
        {
            //Arrange
            DefaultPasswordValidation defaultPassword = new DefaultPasswordValidation();
            AddPasswordDto addPassword = new AddPasswordDto();
            addPassword.Password = null;

            //Act
            var result = defaultPassword.Check(addPassword);

            //Assert
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("abcdefghij")]
        [InlineData("ABCDEFGHIJK")]
        [InlineData("1234567890")]
        [InlineData("!@#$%¨&*-_+")]
        [InlineData("tRG_$O2e")]
        public void DefaultPasswordValidation_InvalidPassword_ReturnIsFalse(string testPassword)
        {
            //Arrange
            DefaultPasswordValidation defaultPassword = new DefaultPasswordValidation();
            AddPasswordDto addPassword = new AddPasswordDto();
            addPassword.Password = testPassword;

            //Act
            var result = defaultPassword.Check(addPassword);

            //Assert
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("AbTp9!foo")]
        [InlineData("7<*XJcv-Q@QBKz;z")]
        [InlineData("5ncxU9uE=hE>e</X")]
        [InlineData("rBr~$LjM5cv{1+57")]
        public void DefaultPasswordValidation_ValidPassword_ReturnIsTrue(string testPassword)
        {
            //Arrange
            DefaultPasswordValidation defaultPassword = new DefaultPasswordValidation();
            AddPasswordDto addPassword = new AddPasswordDto();
            addPassword.Password = testPassword;

            //Act
            var result = defaultPassword.Check(addPassword);

            //Assert
            Assert.True(result.IsValid);
        }
    }
}
