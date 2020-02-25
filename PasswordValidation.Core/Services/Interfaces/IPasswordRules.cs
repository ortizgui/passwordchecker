using PasswordValidation.Core.Dtos;
using PasswordValidation.Core.Services;

namespace PasswordValidation.Core.Interfaces
{
    public interface IPasswordRules
    {
        GetPasswordDto Check(AddPasswordDto password);
    }
}