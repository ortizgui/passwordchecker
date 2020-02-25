using PasswordValidation.Core.Dtos;
using PasswordValidation.Core.Interfaces;

namespace PasswordValidation.Core.Services
{
    public class PasswordValidation
    {
        private IPasswordRules _passwordRules;
        public void SetPasswordRules(IPasswordRules passwordRules)
        {
            this._passwordRules = passwordRules;
        }

        public GetPasswordDto MakePasswordValidations(AddPasswordDto password)
        {
            return _passwordRules.Check(password);
        }
    }
}