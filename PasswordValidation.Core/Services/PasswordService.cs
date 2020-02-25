using PasswordValidation.Core.Dtos;
using PasswordValidation.Core.Interfaces;

namespace PasswordValidation.Core.Services
{
    public class PasswordService : IPasswordService
    {
        public GetPasswordDto PasswordIsValid(AddPasswordDto password)
        {
            GetPasswordDto serviceResponse = new GetPasswordDto();
            PasswordValidation passwordValidation = new PasswordValidation();

            passwordValidation.SetPasswordRules(new DefaultPasswordValidation());

            serviceResponse = passwordValidation.MakePasswordValidations(password); 

            return serviceResponse;
        }
    }
}