using PasswordValidation.Core.Dtos;
using PasswordValidation.Core.Services;

namespace PasswordValidation.Core.Interfaces
{
    public interface IPasswordService
    {
         GetPasswordDto PasswordIsValid(AddPasswordDto password);
    }
}